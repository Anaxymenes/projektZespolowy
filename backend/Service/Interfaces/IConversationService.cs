using System;
using System.Collections.Generic;
using System.Text;
using Data.DTO;

namespace Service.Interfaces
{
    public interface IConversationService
    {
        bool SendMessage(string content, int secondUserId, List<ClaimDTO> list);
        bool DeleteMessage(int messageId, List<ClaimDTO> list);
        bool DeleteConversation(int conversationId, List<ClaimDTO> list);
    }
}
