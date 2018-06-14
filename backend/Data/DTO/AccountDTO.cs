using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }


    }
}
