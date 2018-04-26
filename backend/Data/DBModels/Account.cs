using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModels
{
    public class Account : Entity {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string PasswordSalt { get; set; }

        public Role Role { get; set; }

    }
}
