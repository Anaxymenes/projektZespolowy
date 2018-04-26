using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModels
{
    public class Comment : Entity
    {
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public Post Post { get; set; }
        public Account Author { get; set; }

    }
}
