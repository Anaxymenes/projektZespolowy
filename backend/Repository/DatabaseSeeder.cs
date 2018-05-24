using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DatabaseSeeder{
        public static void SeedAccountRole(DatabaseContext context) {
            if (!context.AccountRole.Any()) {
                var accountRoleList = new List<AccountRole>() {
                    new AccountRole { Name = "Administrator"},
                    new AccountRole { Name = "Użytkownik" }
                };

                context.AddRange(accountRoleList);
                context.SaveChanges();
                DatabaseSeeder.SeedAccount(context);
            }
        }

        public static void SeedAccount(DatabaseContext context) {
            if (!context.Account.Any()) {
                var entityList = new List<Account>() {
                    new Account{
                        Email = "admin@ehobby.com",
                        Active = true,
                        Password = "huJvnFB7W+s+R1VKD5+mVk3Kxl4VLQ9FoKbdwWVj3dM=", // Hasło : @dmIn
                        PasswordSalt="Oa4hhLqKNfKrM5lmBlNp5o2RBMAcb/oZY2JrSliHGPg=",
                        RoleId = context.AccountRole.First(x=>x.Name == "Administrator").Id
                    },
                    new Account{
                        Email = "user@ehobby.com",
                        Active = true,
                        Password = "T3meNC23KoJwxxJFOsOx2fwj3vnh73dYk9tG9k3UIWg=", // Hasło : T3st3r
                        PasswordSalt="/VAB3o32Ct62xq8cxaLC9gHj+FfvZmGmTlneXAVJOq0=",
                        RoleId = context.AccountRole.First(x=>x.Name == "Użytkownik").Id
                    }
                };
                context.AddRange(entityList);
                context.SaveChanges();
                DatabaseSeeder.SeedAccountDetails(context);
            }
        }

        public static void SeedAccountDetails(DatabaseContext context) {
            if (!context.AccountDetails.Any()) {
                var entityList = new List<AccountDetails>() {
                    new AccountDetails {
                        AccountId = context.Account.First(x=>x.Email == "admin@ehobby.com").Id,
                        BirthDate = DateTime.Parse("1989-01-01"),
                        Avatar = "admin.png",
                        Name = "Arthur",
                        LastName = "Admin"
                    },
                    new AccountDetails {
                        AccountId = context.Account.First(x=>x.Email == "user@ehobby.com").Id,
                        BirthDate = DateTime.Parse("1989-03-03"),
                        Avatar = "user.png",
                        Name = "Monika",
                        LastName = "Nowak"
                    },
                };
                context.AddRange(entityList);
                context.SaveChanges();
            }
        }

        public static void SeedHobby(DatabaseContext context) {
            if (!context.Hobby.Any()) {
                var entityList = new List<Hobby>() {

                };
                context.AddRange(entityList);
                context.SaveChanges();
            }
        }

    }
}
