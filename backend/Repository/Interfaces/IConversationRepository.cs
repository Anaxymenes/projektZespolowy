using Data.DBModel;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IConversationRepository
    {
        Conversation FindConversation(int userId, int secondUserId);
        Message SendMessage(int userId, int secondUserId, string content);
        Conversation CreateConversation(int userId, int secondUserId);
        bool DeleteMessage(int messageId, int authorId);
        bool DeleteConversation(int conversationId, int authorId);
        IQueryable<Message> ReturnConversationMessages(int conversationId);
        IQueryable<Conversation> ReturnUserConversations(int userId);
    }
}
