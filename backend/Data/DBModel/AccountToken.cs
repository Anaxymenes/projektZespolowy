using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class AccountToken : Entity{

        
        public string AuthToken { get; set; }
        public DateTime AuthTokenExpires { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpires { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
