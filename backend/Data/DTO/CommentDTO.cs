using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class CommentDTO : Entity
    {
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
