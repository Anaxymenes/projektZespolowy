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

        public Account Account { get; set; }
    }
}
