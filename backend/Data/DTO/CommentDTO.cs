using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public DateTime Date { get; set; }
    }
}
