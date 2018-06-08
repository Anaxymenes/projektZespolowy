using Data.DBModel;
using Data.DTO;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly DatabaseContext _context;

        public ConversationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Conversation CreateConversation(int userId, int secondUserId)
        {
            try
            {
                Conversation newConversation = new Conversation()
                {
                    FirstUserId = userId,
                    SecondUserId = secondUserId,
                    Name = "Konwersacja",
                    StartDate = DateTime.Now
                };
                _context.Add(newConversation);
                _context.SaveChanges();
                return newConversation;
            }
            catch
            {
                return null;
            }
        }

        public bool DeleteConversation(int conversationId, int authorId)
        {
            try
            {
                var conversation = _context.Conversation.First(x => x.Id == conversationId);
                if (conversation.FirstUserId == authorId || conversation.SecondUserId == authorId)
                {
                    _context.Remove(conversation);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMessage(int messageId, int authorId)
        {
            try
            {
                var message = _context.Message.First(x => x.Id == messageId);
                if (message.AuthorId == authorId)
                {
                    _context.Remove(message);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public Conversation FindConversation(int userId, int secondUserId)
        {
            try
            {
                var conversation = _context.Conversation.First(x => ((x.FirstUser.Id == userId && x.SecondUser.Id == secondUserId) || (x.FirstUser.Id == secondUserId && x.SecondUser.Id == userId)));
                return conversation;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Message> ReturnConversationMessages(int conversationId)
        {
            return _context.Message.AsQueryable().Where(x => x.ConversationId == conversationId)
                .Include(a => a.Author)
                    .ThenInclude(aD => aD.AccountDetails);
        }
        

        public IQueryable<Conversation> ReturnUserConversations(int userId)
        {
            var result = _context.Conversation.AsQueryable().Where(x => x.FirstUserId == userId || x.SecondUserId == userId)
                .Include(s => s.SecondUser)
                    .ThenInclude(a => a.AccountDetails);
            foreach(var conversation in result)
            {
                if (conversation.SecondUserId == userId)
                {
                    conversation.SecondUser = conversation.FirstUser;
                }
            }
            return result;
        }

        public Message SendMessage(int userId, int conversationId, string content)
        {
            try
            {
                Message message = new Message()
                {
                    AuthorId = userId,
                    ConversationId = conversationId,
                    Content = content,
                    Date = DateTime.Now
                };
                _context.Add(message);
                _context.SaveChanges();
                return message;
            }
            catch
            {
                return null;
            }
        }
    }
}
