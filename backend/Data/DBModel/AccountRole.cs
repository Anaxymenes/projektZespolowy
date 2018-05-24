using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class AccountRole : Entity {
        public string Name { get; set; }
        public ICollection<Account> Accounts { get; set; }

    }
}
