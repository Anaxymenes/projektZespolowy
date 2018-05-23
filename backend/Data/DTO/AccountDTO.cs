<<<<<<< HEAD
﻿using System;
=======
﻿using Data.DBModels;
using System;
>>>>>>> parent of 907ef6e... Many changes
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
<<<<<<< HEAD
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }


=======
    public class AccountDTO : Entity {
        public string Username { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj) {
            var accountDTO = (AccountDTO)obj;
            return accountDTO.Email == Email && accountDTO.Username == Username && accountDTO.Id == Id;
        }

        public override int GetHashCode() {
            return new { Username, Email, Id }.GetHashCode();
        }
>>>>>>> parent of 907ef6e... Many changes
    }
}
