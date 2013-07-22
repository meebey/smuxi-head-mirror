﻿using System.Linq;
using System;
using JabbR.Models;

namespace JabbR.Services
{
    public interface IJabbrRepository : IDisposable
    {
        IQueryable<ChatRoom> Rooms { get; }
        IQueryable<ChatUser> Users { get; }
        IQueryable<ChatClient> Clients { get; }

        IQueryable<ChatUser> GetOnlineUsers(ChatRoom room);
        IQueryable<ChatUser> GetOnlineUsers();

        IQueryable<ChatUser> SearchUsers(string name);
        IQueryable<ChatMessage> GetMessagesByRoom(ChatRoom room);
        IQueryable<ChatMessage> GetPreviousMessages(string messageId);
        IQueryable<ChatRoom> GetAllowedRooms(ChatUser user);
        IQueryable<Notification> GetNotificationsByUser(ChatUser user);
        ChatMessage GetMessageById(string id);

        ChatUser GetUserById(string userId);
        ChatRoom GetRoomByName(string roomName);

        ChatUser GetUserByName(string userName);
        ChatUser GetUserByClientId(string clientId);
        ChatUser GetUserByLegacyIdentity(string userIdentity);
        ChatUser GetUserByIdentity(string providerName, string userIdentity);
        Notification GetNotificationById(int notificationId);

        ChatClient GetClientById(string clientId, bool includeUser = false);

        void AddUserRoom(ChatUser user, ChatRoom room);
        void RemoveUserRoom(ChatUser user, ChatRoom room);

        void Add(ChatClient client);
        void Add(ChatMessage message);
        void Add(ChatRoom room);
        void Add(ChatUser user);
        void Add(ChatUserIdentity identity);
        void Add(Attachment attachment);

        void Remove(ChatClient client);
        void Remove(ChatRoom room);
        void Remove(ChatUser user);
        void Remove(ChatUserIdentity identity);
        void CommitChanges();

        bool IsUserInRoom(ChatUser user, ChatRoom room);

        // Reload entities from the store
        void Reload(object entity);

        void Add(Notification notification);
        void Remove(Notification notification);
    }
}