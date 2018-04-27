using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModels
{
    public class AccountHobby : Entity{
        public Account Account { get; set; }
        public Hobby Hobby { get; set; }
    }
}
