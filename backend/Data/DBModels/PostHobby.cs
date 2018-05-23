using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModels
{
    public class PostHobby : Entity
    {
        public Post Post { get; set; }
        public int PostId { get; set; }
        public int HobbyId { get; set; }
<<<<<<< HEAD:backend/Data/DBModel/PostHobby.cs

        public Hobby Hobby { get; set; }
        public Post Post { get; set; }
=======
        public Hobby Hooby { get; set; }

>>>>>>> parent of 907ef6e... Many changes:backend/Data/DBModels/PostHobby.cs
    }
}
