using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
