using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class AccountVerification :Entity
    {
        public string CodeVerification { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
