using Data.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
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
    }
}
