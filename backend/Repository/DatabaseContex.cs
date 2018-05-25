using Data.DBModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository {

        public class DatabaseContext : DbContext {

            public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options) { }

            public DbSet<AccountRole> AccountRole { get; set; }
            public DbSet<Account> Account { get; set; }
            public DbSet<AccountDetails> AccountDetails { get; set; }
            public DbSet<Hobby> Hobby { get; set; }
            public DbSet<AccountHobby> AccountHobby { get; set; }
            public DbSet<PostType> PostType { get; set; }
            public DbSet<Post> Post { get; set; }
            public DbSet<PostHobby> PostHobby { get; set; }
            public DbSet<Comment> Comment { get; set; }
            public DbSet<Message> Message { get; set; }
            public DbSet<Conversation> Conversation { get; set; }
            public DbSet<EventDetails> EventDetails { get; set; }
            public DbSet<Picture> Picture { get; set; }
            public DbSet<AccountVerification> AccountVerification { get; set; }
            public DbSet<AccountToken> AccountToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
                //base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<AccountRole>()
                    .HasMany(c => c.Accounts)
                    .WithOne(d => d.AccountRole)
                    .HasForeignKey(b => b.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Account>()
                    .HasMany(x => x.AccountHobbies)
                    .WithOne(x => x.Account)
                    .HasForeignKey(x => x.AccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Account>()
                    .HasMany(x => x.Comments)
                    .WithOne(x => x.Author)
                    .HasForeignKey(x => x.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Account>()
                    .HasMany(x => x.FirstUserConversation)
                    .WithOne(c => c.FirstUser)
                    .HasForeignKey(b => b.FirstUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Account>()
                    .HasMany(x => x.SecondUserConversation)
                    .WithOne(c => c.SecondUser)
                    .HasForeignKey(b => b.SecondUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Account>()
                    .HasMany(x => x.Posts)
                    .WithOne(c => c.Author)
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Account>()
                    .HasMany(x => x.Hobbies)
                    .WithOne(c => c.Administrator)
                    .HasForeignKey(b => b.AdministratorId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                modelBuilder.Entity<Account>()
                    .HasMany(x => x.Messages)
                    .WithOne(c => c.Author)
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Account>()
                    .HasOne(x => x.AccountDetails)
                    .WithOne(c => c.Account)
                    .HasForeignKey<AccountDetails>(b => b.AccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Account>()
                    .HasOne(x => x.AccountVerification)
                    .WithOne(c => c.Account)
                    .HasForeignKey<AccountVerification>(b => b.AccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Account>()
                    .HasOne(x => x.AccountToken)
                    .WithOne(c => c.Account)
                    .HasForeignKey<AccountToken>(b => b.AccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Conversation>()
                    .HasMany(x => x.Messages)
                    .WithOne(c => c.Conversation)
                    .HasForeignKey(b => b.ConversationId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                modelBuilder.Entity<Hobby>()
                    .HasMany(x => x.PostHobbies)
                    .WithOne(c => c.Hobby)
                    .HasForeignKey(b => b.HobbyId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Hobby>()
                    .HasMany(x => x.AccountHobbies)
                    .WithOne(c => c.Hobby)
                    .HasForeignKey(b => b.HobbyId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<PostType>()
                    .HasMany(x => x.Posts)
                    .WithOne(c => c.PostType)
                    .HasForeignKey(b => b.PostTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Post>()
                    .HasMany(x => x.Comments)
                    .WithOne(c => c.Post)
                    .HasForeignKey(b => b.PostId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Post>()
                    .HasMany(x => x.Pictures)
                    .WithOne(c => c.Post)
                    .HasForeignKey(b => b.PostId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Post>()
                    .HasOne(x => x.EventDetalis)
                    .WithOne(c => c.Post)
                    .HasForeignKey<EventDetails>(b => b.PostId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Post>()
                    .HasMany(x => x.PostHobbies)
                    .WithOne(c => c.Post)
                    .HasForeignKey(b => b.PostId);



            //SEED DATA
               
            }


        }
    }

