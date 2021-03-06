﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class AccountDetails : Entity {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Avatar { get; set; }
        public int AccountId { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
    }
}
