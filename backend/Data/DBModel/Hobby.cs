﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class Hobby : Entity {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Color { get; set; }

        public int AdministratorId { get; set; }
        public Account Administrator { get; set; }
        [JsonIgnore]
        public ICollection<PostHobby> PostHobbies { get; set; }
        public ICollection<AccountHobby> AccountHobbies { get; set; }
    }
}
