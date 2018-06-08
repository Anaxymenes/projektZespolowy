using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class ConversationDTO
    {
        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public int SecondUserId { get; set; }
        public string SecondUser { get; set; }
        public ICollection<MessageDTO> Messages { get; set; }

    }
}
