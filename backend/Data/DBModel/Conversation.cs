using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class Conversation : Entity {
        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public int FirstUserId { get; set; }
        public Account FirstUser { get; set; }
        public int SecondUserId { get; set; }
        public Account SecondUser { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}
