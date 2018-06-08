using Data.DBModel;
using Data.DTO;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class ConversationService : IConversationService
    {
        private readonly IConversationRepository _conversationRepository;

        public ConversationService(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public bool DeleteConversation(int conversationId, List<ClaimDTO> claimsList)
        {
            var authorId = Convert.ToInt32(claimsList.Find(x => x.Type == "nameidentifier").Value);
            if (_conversationRepository.DeleteConversation(conversationId, authorId))
                return true;
            return false;
        }

        public bool DeleteMessage(int messageId, List<ClaimDTO> claimsList)
        {
            var authorId = Convert.ToInt32(claimsList.Find(x => x.Type == "nameidentifier").Value);
            if (_conversationRepository.DeleteMessage(messageId, authorId))
                return true;
            return false;
        }

        public bool SendMessage(string content, int secondUserId, List<ClaimDTO> claimsList)
        {
            int userId = Convert.ToInt32(claimsList.Find(x => x.Type == "nameidentifier").Value);
            var conversation = _conversationRepository.FindConversation(userId, secondUserId);
            if (conversation !=null)
            {
                var message = _conversationRepository.SendMessage(userId, conversation.Id, content);
                if (message == null)
                    return false;
                return true;
            }
            else
            {
                _conversationRepository.CreateConversation(userId, secondUserId);
                if(SendMessage(content, secondUserId, claimsList))
                    return true;
                return false;
            }
        }
    }
}
