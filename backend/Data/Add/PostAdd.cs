﻿using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class PostAdd
    {
        public string Content { get; set; }
        public List<HobbyForPostDTO> Hobbys { get; set; }
        public EventDTO Event { get; set; }
    }
}