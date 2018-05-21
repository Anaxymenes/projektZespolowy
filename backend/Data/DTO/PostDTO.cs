using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class PostDTO
    {
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public HobbyForPostDTO Hobby { get; set; }
        public List<string> Pictures { get; set; }
        public EventDTO Event { get; set; }    
    }
}
