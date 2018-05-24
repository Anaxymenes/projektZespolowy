using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class PostType : Entity {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
