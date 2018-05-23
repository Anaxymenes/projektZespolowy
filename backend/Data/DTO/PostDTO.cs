<<<<<<< HEAD
﻿using Data.DBModel;
using System;
=======
﻿using System;
>>>>>>> parent of 907ef6e... Many changes
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class PostDTO
    {
<<<<<<< HEAD
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public List<HobbyForPostDTO> Hobbys { get; set; }
        public List<string> Pictures { get; set; }
        public EventDTO Event { get; set; }    
=======
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public List<PictureDTO> Pictures { get; set; }
        public virtual List<HobbyDTO> Hobbies { get; set; }
        public List<CommentDTO> Comments { get; set; }

>>>>>>> parent of 907ef6e... Many changes
    }
}
