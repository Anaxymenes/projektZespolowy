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
<<<<<<< HEAD
    public class CommentDTO : Entity
    {
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
=======
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public DateTime Date { get; set; }
>>>>>>> parent of 907ef6e... Many changes
    }
}
