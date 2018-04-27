using Data.DBModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app) {
            using(var context = app.ApplicationServices.GetRequiredService<DatabaseContext>()) {
                context.Role.Add(
                    new Role() {
                        Id = 1,
                        Name = "Admin"
                    }
                    );
                context.Role.Add(
                    new Role() {
                        Id = 2,
                        Name = "Moderator"
                    }
                    );
                context.Role.Add(
                    new Role() {
                        Id = 3,
                        Name = "User"
                    }
                    );

                context.SaveChanges();

                //context.Account.Add(
                //    new Account() {
                //        Id = 1,
                //        RoleId = 1,
                //        Password = "/OOoOer10+tGwTRDTrQSoeCxVTFr6dtYly7d0cPxIak=",
                //        PasswordSalt = "NZsP6NnmfBuYeJrrAKNuVQ==",
                //        Email = "admin@admin.pl",
                //        Active = true,
                //        Username = "Admin"
                //    }
                //    );
                //context.Account.Add(
                //    new Account() {
                //        Id = 2,
                //        RoleId = 2,
                //        Password = "/OOoOer10+tGwTRDTrQSoeCxVTFr6dtYly7d0cPxIak=",
                //        PasswordSalt = "NZsP6NnmfBuYeJrrAKNuVQ==",
                //        Email = "moderator@moderator.pl",
                //        Active = true,
                //        Username = "Moderator"
                //    }
                //    );
                //context.Account.Add(
                //    new Account() {
                //        Id = 3,
                //        RoleId = 3,
                //        Password = "/OOoOer10+tGwTRDTrQSoeCxVTFr6dtYly7d0cPxIak=",
                //        PasswordSalt = "NZsP6NnmfBuYeJrrAKNuVQ==",
                //        Email = "user@user.pl",
                //        Active = true,
                //        Username = "User"
                //    }
                //    );

                context.Dispose();
            }
        }
    }
}
