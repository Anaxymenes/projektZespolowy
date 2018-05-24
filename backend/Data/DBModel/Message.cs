using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class Message : Entity {
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public int AuthorId { get; set; }
        public Account Author { get; set; }
    }
}
