using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.DBModel
{
    public class Post : Entity {
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int PostTypeId { get; set; }
        public PostType PostType { get; set; }
        public int AuthorId { get; set; }
        public Account Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        [JsonIgnore]
        public ICollection<PostHobby> PostHobbies { get; set; }
        public EventDetails EventDetalis { get; set; }

    }
}
