using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModels
{
    public class AccountHobby : Entity{
        public Account Account { get; set; }
        public List<Hobby> Hobbies { get; set; }
    }
}
