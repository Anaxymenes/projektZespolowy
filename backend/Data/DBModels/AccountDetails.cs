using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModels
{
    public class AccountDetails : Entity{
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Avatar { get; set; }
        public int AccountId { get; set; }
<<<<<<< HEAD:backend/Data/DBModel/AccountDetails.cs
        [JsonIgnore]
=======


>>>>>>> parent of 907ef6e... Many changes:backend/Data/DBModels/AccountDetails.cs
        public Account Account { get; set; }
    }
}
