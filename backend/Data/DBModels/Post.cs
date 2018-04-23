using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.DBModels
{
    public class Post : Entity
    {
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public PostType PostType { get; set; }
        public Account Author { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
