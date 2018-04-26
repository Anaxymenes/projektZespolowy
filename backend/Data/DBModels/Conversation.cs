using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModels
{
    public class Conversation : Entity
    {
        public DateTime StartDate { get; set; }
        public string Name { get; set; }

        public virtual Account FirstUser { get; set; }
        public virtual Account SecondUser { get; set; }

    }
}
