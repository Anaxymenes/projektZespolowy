using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModels
{
    public class Post : Entity
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }

        public Account Author { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
