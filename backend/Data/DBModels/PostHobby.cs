using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModels
{
    public class PostHobby : Entity
    {
        public Post Post { get; set; }
        public ICollection<Hobby> Hoobies { get; set; }

    }
}
