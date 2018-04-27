using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModels
{
    public class Role : Entity{
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
