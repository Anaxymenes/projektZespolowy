using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class Picture : Entity {
        public string Path { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
