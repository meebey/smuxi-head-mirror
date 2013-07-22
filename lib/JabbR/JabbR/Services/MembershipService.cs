﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using JabbR.Infrastructure;
using JabbR.Models;

namespace JabbR.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IJabbrRepository _repository;
        private readonly ICryptoService _crypto;

        public MembershipService(IJabbrRepository repository, ICryptoService crypto)
        {
            _repository = repository;
            _crypto = crypto;
        }

        public ChatUser AddUser(ClaimsPrincipal claimsPrincipal)
        {
            var identity = claimsPrincipal.GetClaimValue(ClaimTypes.NameIdentifier);
            var name = claimsPrincipal.GetClaimValue(ClaimTypes.Name);
            var email = claimsPrincipal.GetClaimValue(ClaimTypes.Email);
            var providerName = claimsPrincipal.GetIdentityProvider();

            return AddUser(name, providerName, identity, email);
        }

        private ChatUser AddUser(string userName, string providerName, string identity, string email)
        {
            if (!IsValidUserName(userName))
            {
                throw new InvalidOperationException(String.Format("'{0}' is not a valid user name.", userName));
            }

            EnsureProviderAndIdentityAvailable(providerName, identity);

            // This method is used in the auth workflow. If the username is taken it will add a number
            // to the user name.
            if (UserExists(userName))
            {
                var usersWithNameLikeMine = _repository.Users.Count(u => u.Name.StartsWith(userName));
                userName += usersWithNameLikeMine;
            }

            var user = new ChatUser
            {
                Name = userName,
                Status = (int)UserStatus.Active,
                Hash = email.ToMD5(),
                Id = Guid.NewGuid().ToString("d"),
                LastActivity = DateTime.UtcNow,
                IsAdmin = IsFirstUser()
            };

            var chatUserIdentity = new ChatUserIdentity
            {
                User = user,
                Email = email,
                Identity = identity,
                ProviderName = providerName
            };

            _repository.Add(user);
            _repository.Add(chatUserIdentity);
            _repository.CommitChanges();

            return user;
        }

        private bool IsFirstUser()
        {
            return _repository.Users.FirstOrDefault() == null;
        }

        public void LinkIdentity(ChatUser user, ClaimsPrincipal claimsPrincipal)
        {
            var identity = claimsPrincipal.GetClaimValue(ClaimTypes.NameIdentifier);
            var email = claimsPrincipal.GetClaimValue(ClaimTypes.Email);
            var providerName = claimsPrincipal.GetIdentityProvider();

            // Link this new identity
            user.Identities.Add(new ChatUserIdentity
            {
                Email = email,
                Identity = identity,
                ProviderName = providerName
            });
        }

        public ChatUser AddUser(string userName, string email, string password)
        {
            if (!IsValidUserName(userName))
            {
                throw new InvalidOperationException(String.Format("'{0}' is not a valid user name.", userName));
            }

            if (String.IsNullOrEmpty(password))
            {
                ThrowPasswordIsRequired();
            }

            EnsureUserNameIsAvailable(userName);

            var user = new ChatUser
            {
                Name = userName,
                Email = email,
                Status = (int)UserStatus.Active,
                Id = Guid.NewGuid().ToString("d"),
                Salt = _crypto.CreateSalt(),
                LastActivity = DateTime.UtcNow,
                IsAdmin = IsFirstUser()
            };

            ValidatePassword(password);
            user.HashedPassword = password.ToSha256(user.Salt);

            _repository.Add(user);

            return user;
        }

        public bool TryAuthenticateUser(string userName, string password, out ChatUser user)
        {
            user = _repository.GetUserByName(userName);

            if (user == null)
            {
                return false;
            }

            if (user.HashedPassword != password.ToSha256(user.Salt))
            {
                return false;
            }

            EnsureSaltedPassword(user, password);

            return true;
        }

        public void ChangeUserName(ChatUser user, string newUserName)
        {
            if (!IsValidUserName(newUserName))
            {
                throw new InvalidOperationException(String.Format("'{0}' is not a valid user name.", newUserName));
            }

            if (user.Name.Equals(newUserName, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("That's already your username...");
            }

            EnsureUserNameIsAvailable(newUserName);

            // Update the user name
            user.Name = newUserName;
        }

        public void SetUserPassword(ChatUser user, string password)
        {
            ValidatePassword(password);
            user.HashedPassword = password.ToSha256(user.Salt);
        }

        public void ChangeUserPassword(ChatUser user, string oldPassword, string newPassword)
        {
            if (user.HashedPassword != oldPassword.ToSha256(user.Salt))
            {
                throw new InvalidOperationException("Passwords don't match.");
            }

            ValidatePassword(newPassword);

            EnsureSaltedPassword(user, newPassword);
        }

        private static void ValidatePassword(string password)
        {
            if (String.IsNullOrEmpty(password) || password.Length < 6)
            {
                throw new InvalidOperationException("Your password must be at least 6 characters.");
            }
        }

        private static bool IsValidUserName(string name)
        {
            return !String.IsNullOrEmpty(name) && Regex.IsMatch(name, "^[\\w-_.]{1,30}$");
        }

        private void EnsureSaltedPassword(ChatUser user, string password)
        {
            if (String.IsNullOrEmpty(user.Salt))
            {
                user.Salt = _crypto.CreateSalt();
            }
            user.HashedPassword = password.ToSha256(user.Salt);
        }

        private void EnsureUserNameIsAvailable(string userName)
        {
            if (UserExists(userName))
            {
                ThrowUserExists(userName);
            }
        }

        private bool UserExists(string userName)
        {
            return _repository.Users.Any(u => u.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

        private void EnsureProviderAndIdentityAvailable(string providerName, string identity)
        {
            if (ProviderAndIdentityExist(providerName, identity))
            {
                ThrowProviderAndIdentityExist(providerName, identity);
            }
        }

        private bool ProviderAndIdentityExist(string providerName, string identity)
        {
            return _repository.GetUserByIdentity(providerName, identity) != null;
        }

        internal static string NormalizeUserName(string userName)
        {
            return userName.StartsWith("@") ? userName.Substring(1) : userName;
        }

        internal static void ThrowUserExists(string userName)
        {
            throw new InvalidOperationException(String.Format("Username {0} already taken.", userName));
        }

        internal static void ThrowPasswordIsRequired()
        {
            throw new InvalidOperationException("A password is required.");
        }

        internal static void ThrowProviderAndIdentityExist(string providerName, string identity)
        {
            throw new InvalidOperationException(String.Format("Identity {0} already taken with Provider {1}, please login with a different provider/identity combination.", identity, providerName));
        }
    }
}