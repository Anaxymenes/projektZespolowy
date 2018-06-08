using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int ConversationId { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
    }
}
