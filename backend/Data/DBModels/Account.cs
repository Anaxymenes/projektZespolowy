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
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public AccountDetails AccountDetails { get; set; }
        public ICollection<AccountHobby> AccountHobbies { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Conversation> FirstUserConversation { get; set; }
        public ICollection<Conversation> SecondUserConversation { get; set; }
        public ICollection<Post> Posts{ get; set; }
        public ICollection<Hobby> Hobbies { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
