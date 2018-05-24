using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class HashedPassword
    {
        public string Password { get; set; }
        public string PasswordHashed { get; set; }
        public string Salt { get; set; }
    }
}
