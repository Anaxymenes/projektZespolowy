using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class Comment : Entity {
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public Account Author { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
