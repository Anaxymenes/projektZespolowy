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
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder) {

        //}

    }
}
