﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModels
{
    public class PostHobby : Entity
    {
        public Post Post { get; set; }
        public int PostId { get; set; }
        public int HobbyId { get; set; }
        public Hobby Hooby { get; set; }

    }
}
