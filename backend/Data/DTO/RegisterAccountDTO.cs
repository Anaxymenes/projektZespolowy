using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class RegisterAccountDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsValid() {
            if (
                this.Email != null &&
                this.Email.Contains("@") &&
                this.Password != null &&
                this.FirstName != null &&
                this.LastName != null &&
                this.BirthDate != null
                )
                return true;
            return false;
        }
    }
}
