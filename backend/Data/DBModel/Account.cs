using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class Account : Entity {
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string PasswordSalt { get; set; }
        public int RoleId { get; set; }
        public AccountRole AccountRole { get; set; }
        public AccountDetails AccountDetails { get; set; }
        [JsonIgnore]
        public ICollection<AccountHobby> AccountHobbies { get; set; }
        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
        [JsonIgnore]
        public ICollection<Conversation> FirstUserConversation { get; set; }
        [JsonIgnore]
        public ICollection<Conversation> SecondUserConversation { get; set; }
        [JsonIgnore]
        public ICollection<Post> Posts { get; set; }
        [JsonIgnore]
        public ICollection<Hobby> Hobbies { get; set; }
        [JsonIgnore]
        public ICollection<Message> Messages { get; set; }
    }
}
