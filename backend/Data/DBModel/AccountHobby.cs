using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class AccountHobby : Entity {
        public int AccountId { get; set; }
        public int HobbyId { get; set; }

        public Hobby Hobby { get; set; }
        public Account Account { get; set; }
    }
}
