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
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>()
                .HasMany(c => c.Accounts)
                .WithOne(e => e.Role)
                .HasForeignKey(b => b.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasOne(c => c.AccountDetails)
                .WithOne(e => e.Account)
                .HasForeignKey<AccountDetails>(b => b.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                .HasMany(c => c.AccountHobbies)
                .WithOne(e => e.Account);

            modelBuilder.Entity<Account>()
                .HasMany(c => c.Comments)
                .WithOne(e => e.Author);

            modelBuilder.Entity<Account>()
                .HasMany(c => c.FirstUserConversation)
                .WithOne(e => e.FirstUser);

            modelBuilder.Entity<Account>()
                .HasMany(c => c.SecondUserConversation)
                .WithOne(e => e.SecondUser);

            modelBuilder.Entity<Account>()
                .HasMany(c => c.Posts)
                .WithOne(e => e.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasMany(c => c.Hobbies)
                .WithOne(e => e.Administrator);

            modelBuilder.Entity<Account>()
                .HasMany(c => c.Messages)
                .WithOne(e => e.Author);

            modelBuilder.Entity<PostType>()
                .HasMany(c => c.Posts)
                .WithOne(e => e.PostType)
                .HasForeignKey(b => b.PostTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hobby>()
                .HasMany(c => c.AccountHobbies)
                .WithOne(e => e.Hobby);

            modelBuilder.Entity<Hobby>()
                .HasMany(c => c.PostHobbies)
                .WithOne(e => e.Hooby)
                .HasForeignKey(b => b.HobbyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Conversation>()
                .HasMany(c => c.Messages)
                .WithOne(e => e.Conversation);

            modelBuilder.Entity<Post>()
                .HasMany(c => c.Pictures)
                .WithOne(e => e.Post)
                .HasForeignKey(b => b.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasMany(c => c.PostHobbies)
                .WithOne(e => e.Post)
                .HasForeignKey(b => b.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasMany(c => c.Comments)
                .WithOne(e => e.Post)
                .HasForeignKey(b => b.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasMany(c => c.EventDetails)
                .WithOne(e => e.Post);
        }

        

    }
}
