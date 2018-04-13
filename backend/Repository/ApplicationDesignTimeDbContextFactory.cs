using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repository
{
    public class ApplicationDesignTimeDbContextFactory :
        IDesignTimeDbContextFactory<DatabaseContext> {
        public DatabaseContext CreateDbContext(string[] args) {
            var path = Path.Combine(AppContext.BaseDirectory,
                "..\\..\\..\\..\\WebApi");
            var builder =
                new ConfigurationBuilder().SetBasePath(path)
                .AddJsonFile("appsettings.json", false, true);
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            var connectionString = configuration.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(connectionString);
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
