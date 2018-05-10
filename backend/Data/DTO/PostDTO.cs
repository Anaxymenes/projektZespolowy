using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public List<PictureDTO> Pictures { get; set; }
        public virtual List<HobbyDTO> Hobbies { get; set; }
        public List<CommentDTO> Comments { get; set; }

    }
}
