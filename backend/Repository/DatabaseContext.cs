using Data.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;

namespace Repository
{
    public class DatabaseContext : DbContext{

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options) {}

        public DbSet<Role> Role { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Hobby> Hobby { get; set; }
        public DbSet<AccountDetails> AccountDetails { get; set; }
        public DbSet<AccountHobby> AccountHobby { get; set; }
        public DbSet<PostType> PostType { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostHobby> PostHobby { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<EventDetails> EventDetails { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Picture> Picture { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder) {

        //}

    }
}
