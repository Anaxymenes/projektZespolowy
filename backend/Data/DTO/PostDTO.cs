using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public string AuthorAvatar { get; set; }
        public List<HobbyForPostDTO> Hobbys { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public List<string> Pictures { get; set; }
        public EventDTO Event { get; set; }    
    }
}
