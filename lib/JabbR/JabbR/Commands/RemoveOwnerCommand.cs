﻿using System;
using JabbR.Models;

namespace JabbR.Commands
{
    [Command("removeowner", "Remove an owner from the specified room. Only works if you're the creator of that room.", "user [room]", "room")]
    public class RemoveOwnerCommand : UserCommand
    {
        public override void Execute(CommandContext context, CallerContext callerContext, ChatUser callingUser, string[] args)
        {
            if (args.Length == 0)
            {
                throw new InvalidOperationException("Which owner do you want to remove?");
            }

            string targetUserName = args[0];

            ChatUser targetUser = context.Repository.VerifyUser(targetUserName);

            string roomName = args.Length > 1 ? args[1] : callerContext.RoomName;

            if (String.IsNullOrEmpty(roomName))
            {
                throw new InvalidOperationException("Which room?");
            }

            ChatRoom targetRoom = context.Repository.VerifyRoom(roomName);

            context.Service.RemoveOwner(callingUser, targetUser, targetRoom);

            context.NotificationService.RemoveOwner(targetUser, targetRoom);

            context.Repository.CommitChanges();
        }
    }
}