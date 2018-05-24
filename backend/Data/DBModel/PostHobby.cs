using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class PostHobby : Entity {
        public int PostId { get; set; }
        public int HobbyId { get; set; }

        public Hobby Hobby { get; set; }
        public Post Post { get; set; }

    }
}
