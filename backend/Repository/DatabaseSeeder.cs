using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DatabaseSeeder{

        public static void SeedData(DatabaseContext context) {
            string adminRole = "Administrator";
            string moderatorRole = "Moderator";
            string userRole = "Użytkownik";
            Random rnd = new Random();
            if (!context.AccountRole.Any()) {
                var list = new List<AccountRole>() {
                    new AccountRole {  Name = adminRole},
                    new AccountRole {  Name = moderatorRole},
                    new AccountRole { Name = userRole }
                };
                context.AddRange(list);
                context.SaveChanges();
            }

            if (!context.Account.Any()) {
                var list = new List<Account>() {
                    new Account {
                        Active = true,
                        Email = "admin@ehobby.com",
                        Password="rVwrEeygFCbjtUtqnwYwzyqqjAZjsWehhNyZot26f+8=", // hasło : admin
                        PasswordSalt="GZa8vMuhZRebUIuy4R44zltkrnDMx5kaWGxb6dTqMoU=",
                        RoleId = 1,
                    },
                    new Account {
                        Active = true,
                        Email = "moderator@ehobby.com",
                        Password="rVwrEeygFCbjtUtqnwYwzyqqjAZjsWehhNyZot26f+8=", // hasło : admin
                        PasswordSalt="GZa8vMuhZRebUIuy4R44zltkrnDMx5kaWGxb6dTqMoU=",
                        RoleId = 2,
                    },
                    new Account {
                        Active = true,
                        Email = "user@ehobby.com",
                        Password="onTIiwNhHTtBxdAgyeiq7lvC0Lfz1NqFcDNjzunAifg=", // hasło : 1234
                        PasswordSalt="CYEWqX7QhuMZsXLe9UolwF7sJM+pe1nWsEeqoscHtyg=",
                        RoleId = 3,
                    },
                    new Account {
                        Active = true,
                        Email = "tester@test.com",
                        Password="onTIiwNhHTtBxdAgyeiq7lvC0Lfz1NqFcDNjzunAifg=", // hasło : 1234
                        PasswordSalt="CYEWqX7QhuMZsXLe9UolwF7sJM+pe1nWsEeqoscHtyg=",
                        RoleId = 3,
                    },
                    new Account {
                        Active = true,
                        Email = "jjsdfloiewr@ehobby.com",
                        Password="onTIiwNhHTtBxdAgyeiq7lvC0Lfz1NqFcDNjzunAifg=", // hasło : 1234
                        PasswordSalt="CYEWqX7QhuMZsXLe9UolwF7sJM+pe1nWsEeqoscHtyg=",
                        RoleId = 3,
                    },
                };
                context.AddRange(list);
                context.SaveChanges();
            }
            if (!context.AccountDetails.Any()) {
                var list = new List<AccountDetails>() {
                    new AccountDetails {
                        Avatar = "img/account/defaultProfile.jpg",
                        BirthDate = new DateTime (rnd.Next(1940,2000), rnd.Next(1,12), rnd.Next(1,28)),
                        Name = "Niecisław",
                        LastName = "Bizub",
                        AccountId = 1,
                    },
                    new AccountDetails {
                        Avatar = "img/account/defaultProfile.jpg",
                        BirthDate = new DateTime (rnd.Next(1940,2000), rnd.Next(1,12), rnd.Next(1,28)),
                        Name = "Anastazja",
                        LastName = "Dobrzyjalowska",
                        AccountId = 2,
                    },
                    new AccountDetails {
                        Avatar = "img/account/defaultProfile.jpg",
                        BirthDate = new DateTime (rnd.Next(1940,2000), rnd.Next(1,12), rnd.Next(1,28)),
                        Name = "Winris",
                        LastName = "Grandseeker",
                        AccountId = 3,
                    },
                    new AccountDetails {
                        Avatar = "img/account/defaultProfile.jpg",
                        BirthDate = new DateTime (rnd.Next(1940,2000), rnd.Next(1,12), rnd.Next(1,28)),
                        Name = "Maryna Valeriyivna",
                        LastName = "Khyzhnyak",
                        AccountId = 4,
                    },
                    new AccountDetails {
                        Avatar = "img/account/defaultProfile.jpg",
                        BirthDate = new DateTime (rnd.Next(1940,2000), rnd.Next(1,12), rnd.Next(1,28)),
                        Name = "Marián",
                        LastName = "Vašíček",
                        AccountId = 5,
                    },
                };
                context.AddRange(list);
                context.SaveChanges();
            }

            if (!context.PostType.Any()) {
                var list = new List<PostType>() {
                    new PostType { Name = "Common"},
                    new PostType { Name = "Picture"},
                    new PostType { Name = "Event" }
                };
                context.AddRange(list);
                context.SaveChanges();
            }

            if (!context.Hobby.Any()) {
                var list = new List<Hobby>() {
                    new Hobby {
                        AdministratorId = 2,
                        Color = "#FF3909",
                        Description = "Cras feugiat nisl vulputate ex feugiat tincidunt. Pellentesque consectetur eros metus, nec dignissim nibh gravida a. Sed in lectus scelerisque, venenatis libero at, facilisis augue. Proin ut ultrices mi, ac varius erat. Fusce porta sit amet odio varius auctor. Nulla eros augue, auctor et scelerisque in, facilisis quis eros. Maecenas ac lobortis libero, eget varius turpis. Mauris at neque venenatis, maximus eros ac, mollis lacus. Duis lacinia lobortis dolor id molestie. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nullam eu rutrum massa. Ut interdum justo et egestas viverra. Vivamus felis felis, cursus in gravida vel, tincidunt ut risus. Morbi non arcu dictum, venenatis neque in, venenatis eros. Vestibulum elementum nibh vel nisl mattis, sit amet varius nibh vehicula. Curabitur a maximus dolor. Pellentesque sed sapien arcu. Quisque vehicula metus odio, eget tincidunt risus vehicula nec. Cras dapibus eros at velit ullamcorper, ut tincidunt ante tempus. Praesent eu orci tellus. Nulla vel accumsan erat. In nec lacus dapibus, rhoncus enim at, mollis sem. Sed a imperdiet quam. Integer rutrum augue quis ligula tincidunt, eu cursus nisl iaculis. ",
                        Name = "Tenis",
                        Logo = "img/hobby/tennis.jpg"
                    },
                    new Hobby {
                        AdministratorId = 2,
                        Color = "#E8B51B",
                        Description = "Vestibulum cursus massa eros, ac lacinia nisl consequat vitae. Donec nec accumsan ex. Nam sit amet augue dapibus, tincidunt mi vitae, dictum mi. Pellentesque mollis venenatis ex ac convallis. In hac habitasse platea dictumst. Vivamus lacinia sollicitudin eros at rutrum. Curabitur eget lacinia felis. Sed et ligula vitae augue ornare eleifend. Fusce porttitor congue libero, tincidunt ultricies magna porta hendrerit. Ut feugiat lorem in nisi cursus, finibus suscipit dui posuere. Praesent ut ornare magna, finibus luctus dui. Proin tempus eros ut mi consequat lobortis. Aenean vitae enim eu nunc sodales congue eget nec augue.",
                        Name = "Skateboarding",
                        Logo = "img/hobby/skateboarding.jpg"
                    },
                    new Hobby {
                        AdministratorId = 4,
                        Color = "#FF1D11",
                        Description = "Duis ut porta odio, eu cursus arcu. Pellentesque id urna id tellus auctor ullamcorper non et purus. Sed mollis sem id leo maximus elementum. Nulla pharetra, quam at rhoncus imperdiet, nibh lacus consequat massa, vel ornare quam leo pharetra purus. Vestibulum id convallis sem. Fusce sed libero facilisis, laoreet metus in, tristique magna. Vestibulum ut elit at arcu sodales lobortis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Cras rhoncus sagittis pellentesque. Quisque dolor sapien, pellentesque id semper nec, tincidunt id nulla. Maecenas pharetra pharetra augue, porttitor mattis ex ultricies at. Suspendisse interdum metus ex, ut aliquam justo interdum tempor. ",
                        Name = "Telefony komórkowe",
                        Logo = "img/hobby/mobilePhone.jpg"
                    },
                    new Hobby {
                        AdministratorId = 5,
                        Color = "#1125A6",
                        Description = "Pellentesque ut libero pellentesque magna feugiat varius. Nulla arcu enim, tincidunt eu massa non, dictum elementum dolor. Pellentesque vel mi erat. Quisque quis urna pellentesque, vulputate tellus eget, euismod neque. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean sollicitudin, nisi id porttitor placerat, turpis erat consectetur turpis, id dapibus lacus arcu et tellus. Praesent in vestibulum risus. Nulla ullamcorper dolor vel metus sodales, in cursus ligula feugiat. Sed scelerisque sem orci, nec tristique leo accumsan euismod. Aliquam tempus euismod nibh, ut sagittis erat finibus a. Ut non enim eu eros scelerisque iaculis. ",
                        Name = "Programowanie",
                        Logo = "img/hobby/programming.jpg"
                    },
                    new Hobby {
                        AdministratorId = 1,
                        Color = "#A63A13",
                        Description = "Aliquam erat volutpat. Maecenas orci tortor, convallis a tristique at, fringilla eu felis. Praesent gravida vehicula nisi, sed interdum libero maximus in. Fusce justo nunc, mattis eget luctus quis, facilisis ut odio. Suspendisse at ullamcorper nunc. Nunc finibus lectus a fermentum venenatis. Sed accumsan dui sit amet congue ultrices. Integer porttitor vitae risus id fermentum. Suspendisse aliquet rutrum porta. Morbi erat tortor, semper malesuada ullamcorper quis, rhoncus nec est. Aliquam egestas nisi eu quam porttitor hendrerit. Proin tincidunt tellus nulla, convallis fermentum justo vulputate eu. In id tincidunt arcu, quis commodo orci. Sed ac libero velit. Proin mollis, nisl ac iaculis euismod, libero justo posuere tellus, non vulputate ex velit eu mauris. Praesent sit amet dignissim ipsum. ",
                        Name = "Motocross",
                        Logo = "img/hobby/motocross.jpg"
                    },
                    new Hobby {
                        AdministratorId = 1,
                        Color = "#FFFAE1",
                        Description = "Integer lacus ante, lacinia ac nibh in, sodales luctus ipsum. Cras consequat cursus turpis vitae tristique. Nunc efficitur lectus vitae sapien aliquam, non semper turpis placerat. Duis porttitor odio lorem, non auctor augue imperdiet vitae. Maecenas posuere tellus a enim hendrerit vehicula. Sed semper nisl augue, ut auctor risus hendrerit in. Cras a malesuada libero. Quisque quis nulla ultricies, euismod lectus quis, malesuada orci. Mauris nisi velit, tempus vitae fringilla in, aliquet a risus. ",
                        Name = "Hokej",
                        Logo = "img/hobby/iceHockey.jpg"
                    },
                    new Hobby {
                        AdministratorId = 3,
                        Color = "#292824",
                        Description = "In hac habitasse platea dictumst. Praesent ullamcorper felis at magna ultricies euismod. Pellentesque ornare mattis eros eget lobortis. Ut vitae purus arcu. Curabitur sed sollicitudin augue. Nam nec nunc eget enim euismod tempus a ac nulla. Nullam scelerisque non urna eget fringilla. Donec purus sem, vestibulum id ipsum venenatis, finibus accumsan tortor. Curabitur dignissim ipsum erat, eu euismod nunc pellentesque at. ",
                        Name = "Karty",
                        Logo = "img/hobby/cards.jpg"
                    },
                    new Hobby {
                        AdministratorId = 1,
                        Color = "#590C6D",
                        Description = "Donec ipsum velit, tristique facilisis vestibulum nec, luctus in urna. Quisque placerat gravida sapien, ut vestibulum tortor scelerisque aliquam. Nunc tincidunt suscipit dapibus. Nulla bibendum vehicula luctus. Integer mattis augue nibh, at suscipit sem convallis id. Integer ut finibus purus. Pellentesque tincidunt nunc in porttitor porttitor. Suspendisse sed magna consequat, bibendum nisi in, volutpat nisi. Quisque laoreet lorem et faucibus tempor. Sed quis nisl in ipsum volutpat maximus. ",
                        Name = "Koszykówka",
                        Logo = "img/hobby/basketball.jpg"
                    },
                    new Hobby {
                        AdministratorId = 1,
                        Color = "#BA170D",
                        Description = "Nullam vitae elementum turpis. Nulla facilisi. Duis in ex metus. Mauris mollis metus at accumsan congue. Ut laoreet tellus eget felis pretium condimentum. Etiam eleifend dolor vitae velit tincidunt dapibus. Fusce ipsum est, efficitur nec libero vitae, congue cursus libero. Cras ut interdum mi. Sed vulputate, orci ut rutrum lobortis, massa metus posuere massa, id dignissim risus dui volutpat augue. Sed ut convallis tortor, vitae suscipit lacus. Nam tincidunt leo in sem finibus finibus nec sit amet dui. Aliquam commodo enim id maximus consectetur. Aenean nec dictum sapien, eu fringilla erat. ",
                        Name = "Gry",
                        Logo = "img/hobby/gaming.jpg"
                    },
                    new Hobby {
                        AdministratorId = 5,
                        Color = "#0A8200",
                        Description = "Quisque vehicula, metus vel porta consequat, dolor metus blandit leo, id eleifend arcu sapien et lectus. Nulla dictum odio a lectus maximus posuere. Curabitur convallis mollis consectetur. Nam mi nulla, malesuada ut nibh ac, mollis blandit lacus. Nam semper turpis risus, vitae gravida risus scelerisque ac. Vivamus dignissim lorem ut dictum vulputate. Nunc aliquam quam eu orci aliquam, id molestie nisi ullamcorper. Fusce ac dui ligula. Curabitur pretium lorem quis dictum consectetur. Nullam porttitor dui vitae condimentum tincidunt. Duis tortor mi, sagittis at erat sed, mollis molestie nunc. Mauris convallis at risus et accumsan. Nulla cursus vestibulum neque vitae consectetur.",
                        Name = "Bilard",
                        Logo = "img/hobby/billiard.jpg"

                    },
                };
                context.AddRange(list);
                context.SaveChanges();
            }

            if (!context.AccountHobby.Any()) {
                var list = new List<AccountHobby>() {
                    new AccountHobby {
                        AccountId = 2,
                        HobbyId = 1,
                    },
                    new AccountHobby {
                        AccountId = 2,
                        HobbyId = 2,
                    },
                    new AccountHobby {
                        AccountId = 4,
                        HobbyId = 3,
                    },
                    new AccountHobby {
                        AccountId = 5,
                        HobbyId = 4,
                    },
                    new AccountHobby {
                        AccountId = 1,
                        HobbyId = 5,
                    },
                    new AccountHobby {
                        AccountId = 1,
                        HobbyId = 6,
                    },
                    new AccountHobby {
                        AccountId = 3,
                        HobbyId = 7,
                    },
                    new AccountHobby {
                        AccountId = 1,
                        HobbyId = 8,
                    },
                    new AccountHobby {
                        AccountId = 1,
                        HobbyId = 9,
                    },
                    new AccountHobby {
                        AccountId = 5,
                        HobbyId = 10,
                    },
                    new AccountHobby {
                        AccountId = 5,
                        HobbyId = 1,
                    },
                    new AccountHobby {
                        AccountId = 5,
                        HobbyId = 2,
                    },
                    new AccountHobby {
                        AccountId = 1,
                        HobbyId = 10,
                    },
                    new AccountHobby {
                        AccountId = 3,
                        HobbyId = 4,
                    },
                    new AccountHobby {
                        AccountId = 3,
                        HobbyId = 5,
                    },
                    new AccountHobby {
                        AccountId = 4,
                        HobbyId = 7,
                    },
                };
                context.AddRange(list);
                context.SaveChanges();
            }
            if (!context.Post.Any()) {
                var list = new List<Post>() {
                    new Post {
                        AuthorId = 1,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 1,
                        Content = "Phasellus quis nisl ante. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque elit sapien, dictum posuere orci ac, fringilla interdum dolor. Cras tempor turpis sed volutpat tincidunt. Proin volutpat felis ante, in feugiat ante vehicula vel. Nullam ultrices, ligula in commodo pretium, nulla ipsum consectetur tellus, eget interdum felis sem vitae tellus. ",
                    },
                    new Post {
                        AuthorId = 2,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 1,
                        Content = "Maecenas vel leo et nunc iaculis accumsan. Quisque libero tortor, aliquam vitae ornare nec, vehicula vitae urna. Sed tristique, quam sit amet consectetur facilisis, neque tellus gravida diam, at efficitur nisi est nec ante. Sed nisl sem, euismod tristique nunc at, tempor ultrices ligula.",
                    },
                    new Post {
                        AuthorId = 3,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 1,
                        Content = "Donec felis felis, pretium sit amet ex a, congue imperdiet nulla. Donec suscipit neque sed ligula ultrices, non interdum sapien rhoncus. ",
                    },
                    new Post {
                        AuthorId = 4,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 1,
                        Content = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla varius ultrices urna, at accumsan dolor tempus eu. Pellentesque vitae ex euismod, placerat erat quis, pulvinar diam amet. ",
                    },
                    new Post {
                        AuthorId = 5,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 1,
                        Content = "Maecenas rhoncus vestibulum condimentum. In ultricies id ipsum et tempor. Nulla facilisi. Vestibulum et lorem nulla. Aliquam id velit auctor, tincidunt nunc et, maximus mi. Donec mattis mollis luctus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Sed condimentum leo ante, non feugiat lorem viverra cursus. Curabitur placerat malesuada arcu vel fermentum. Vestibulum aliquam nunc vel rutrum viverra. Integer rutrum a nisl eget consectetur. Maecenas vitae velit eget orci semper sollicitudin vitae eu lectus. Etiam diam felis, tincidunt non eros amet. ",
                    },
                    new Post {
                        AuthorId = 1,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 1,
                        Content = "Proin turpis diam, vestibulum non rutrum ut, tristique in velit. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec interdum tristique eros ac vulputate. Duis sit amet arcu a arcu facilisis pretium aliquam id lacus. Aliquam eget mattis lacus. Phasellus ultricies neque nec eros efficitur sodales. ",
                    },
                    new Post {
                        AuthorId = 2,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 1,
                        Content = "In pellentesque lectus arcu, sit amet pellentesque eros convallis in. Donec ac pharetra nisl. Suspendisse tincidunt finibus risus. Fusce rutrum vestibulum nisl quis eleifend. Sed blandit dictum mi, quis pharetra elit pulvinar eget. Sed finibus lectus quis lacus viverra, et tincidunt mauris suscipit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Quisque mattis felis laoreet condimentum dictum. Nam commodo ipsum est, nec tempor ligula faucibus sed. Morbi eleifend metus lectus, nec ultrices nulla euismod ac. Pellentesque dignissim pulvinar ligula eget pellentesque. Nunc pulvinar metus a nisl congue, vel suscipit sem consequat. Morbi urna nunc, tempus scelerisque malesuada sed, imperdiet eget nibh. Nulla facilisi. ",
                    },
                    new Post {
                        AuthorId = 3,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 1,
                        Content = "Aenean eget metus neque. In ultrices enim id tellus cursus dapibus. Nunc non augue ut dolor vestibulum rhoncus. Suspendisse sollicitudin ultrices nunc. Nunc aliquet leo nibh, ut sollicitudin purus luctus consectetur. Morbi semper luctus ultricies. Ut vitae metus. ",
                    },
                    new Post {
                        AuthorId = 4,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 1,
                        Content = "Vivamus condimentum vel elit sit amet mattis. Nulla facilisi. Aliquam convallis eu quam sit amet ullamcorper. Integer diam leo, tempor sed egestas eu, blandit vel metus. Mauris ex dui, egestas suscipit elit at, sollicitudin tempor dolor. Sed ultricies lacus vel cursus sodales. Maecenas nisi quam, scelerisque ut molestie a, finibus sed sem. Aenean blandit lorem tortor, ut luctus erat tincidunt eu. Phasellus ullamcorper massa ornare mollis gravida.",
                    },
                    new Post {
                        AuthorId = 5,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "Interdum et malesuada fames ac ante ipsum primis in faucibus. Quisque et ornare ex, et pulvinar ligula. Quisque sit amet dui ipsum. Vivamus sit amet mi id arcu rhoncus ullamcorper. Praesent cursus libero libero, vel porttitor odio gravida nec. Nam ullamcorper, est id fermentum vulputate, turpis arcu varius diam, sed tincidunt metus augue eu mauris. Aenean justo metus, aliquam pellentesque accumsan in, fermentum ac libero. Aliquam aliquet euismod urna, vitae feugiat metus egestas nec. Curabitur ut condimentum purus. Aenean et dolor eget ante viverra semper turpis duis. ",
                    },
                    new Post {
                        AuthorId = 2,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "Etiam euismod enim in luctus maximus. ",
                    },
                    new Post {
                        AuthorId = 1,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "",
                    },
                    new Post {
                        AuthorId = 1,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas",
                    },
                    new Post {
                        AuthorId = 2,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "Quisque sit amet",
                    },
                    new Post {
                        AuthorId = 2,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "Nam tristique egestas tristique. ",
                    },
                    new Post {
                        AuthorId = 3,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "Praesent ullamcorper porta neque, at dapibus",
                    },
                    new Post {
                        AuthorId = 3,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "",
                    },
                    new Post {
                        AuthorId = 4,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "Aenean elementum lacus sed mauris malesuada, sed aliquet nibh tempor.",
                    },
                    new Post {
                        AuthorId = 4,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "",
                    },
                    new Post {
                        AuthorId = 5,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "Nullam at risus sed ",
                    },
                    new Post {
                        AuthorId = 5,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "Mauris rutrum venenatis erat et porta. Praesent vulputate urna quis turpis",
                    },
                    new Post {
                        AuthorId = 1,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "ultricies quis risus et, congue dignissim ex.",
                    },
                    new Post {
                        AuthorId = 1,
                        Date = new DateTime (rnd.Next(2012,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostTypeId = 2,
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    },
                };
                context.AddRange(list);
                context.SaveChanges();
            }

            if (!context.PostHobby.Any()) {
                var list = new List<PostHobby>() {
                    new PostHobby { HobbyId = 5, PostId = 1 },
                    new PostHobby { HobbyId = 9, PostId = 1 },
                    new PostHobby { HobbyId = 1, PostId = 2 },
                    new PostHobby { HobbyId = 7, PostId = 3 },
                    new PostHobby { HobbyId = 3, PostId = 4 },
                    new PostHobby { HobbyId = 4, PostId = 5},
                    new PostHobby { HobbyId = 10, PostId = 5 },
                    new PostHobby { HobbyId = 8, PostId = 6 },
                    new PostHobby { HobbyId = 5, PostId = 6 },
                    new PostHobby { HobbyId = 1, PostId = 7 },
                    new PostHobby { HobbyId = 2, PostId = 7 },
                    new PostHobby { HobbyId = 7, PostId = 8 },
                    new PostHobby { HobbyId = 3, PostId = 9 },
                    new PostHobby { HobbyId = 4, PostId = 9 },
                    new PostHobby { HobbyId = 4, PostId = 10 },
                    new PostHobby { HobbyId = 2, PostId = 11 },
                    new PostHobby { HobbyId = 6, PostId = 12 },
                    new PostHobby { HobbyId = 9, PostId = 13 },
                    new PostHobby { HobbyId = 10, PostId = 13 },
                    new PostHobby { HobbyId = 1, PostId = 14 },
                    new PostHobby { HobbyId = 1, PostId = 15 },
                    new PostHobby { HobbyId = 5, PostId = 16 },
                    new PostHobby { HobbyId = 7, PostId = 17 },
                    new PostHobby { HobbyId = 3, PostId = 18 },
                    new PostHobby { HobbyId = 7, PostId = 19 },
                    new PostHobby { HobbyId = 10, PostId = 20 },
                    new PostHobby { HobbyId = 4, PostId = 20 },
                    new PostHobby { HobbyId = 4, PostId = 21 },
                    new PostHobby { HobbyId = 10, PostId = 22 },
                    new PostHobby { HobbyId = 8, PostId = 23 },
                };
                context.AddRange(list);
                context.SaveChanges();
            }

            if (!context.Picture.Any()) {
                var list = new List<Picture>() {
                    new Picture { Path = "img/hobby/mobilephone_post_01.jpg" , PostId = 10},
                    new Picture { Path = "img/hobby/skateboarding_post_01.jpeg" , PostId = 11},
                    new Picture { Path = "img/hobby/icehockey_post_01.jpeg" , PostId = 12},
                    new Picture { Path = "img/hobby/gaming_post_01.jpeg" , PostId = 13},
                    new Picture { Path = "img/hobby/tennis_post_01.jpeg" , PostId = 14},
                    new Picture { Path = "img/hobby/tennis_post_02.jpeg" , PostId = 15},
                    new Picture { Path = "img/hobby/motocross_post_01.jpeg" , PostId = 16},
                    new Picture { Path = "img/hobby/cards_post_01.jpeg" , PostId = 17},
                    new Picture { Path = "img/hobby/mobilephone_post_02.jpg" , PostId = 18},
                    new Picture { Path = "img/hobby/cards_post_02.jpeg" , PostId = 19},
                    new Picture { Path = "img/hobby/programming_post_01.jpeg" , PostId = 20},
                    new Picture { Path = "img/hobby/programming_post_02.jpeg" , PostId = 21},
                    new Picture { Path = "img/hobby/billiard_post_01.jpg" , PostId = 22},
                    new Picture { Path = "img/hobby/basketball_post_01.jpeg" , PostId = 23},
                };
                context.AddRange(list);
                context.SaveChanges();
            }

            if (!context.Comment.Any()) {
                var list = new List<Comment>() {
                    new Comment {
                        AuthorId = 1,
                        Content = "Eiusmod pariatur sunt prosciutto kielbasa beef ribs chicken deserunt hamburger aliquip. Enim commodo ut salami quis deserunt pancetta ground round nostrud pariatur eu beef pork chop. Cillum ball tip labore id beef ribs eu in leberkas tongue enim. Flank in pastrami velit pork chop exercitation.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 2,
                    },
                    new Comment {
                        AuthorId = 4,
                        Content = "Turkey pork loin culpa sirloin ground round duis magna. Pork loin ipsum elit ad velit, dolore eu tenderloin corned beef turducken aliqua qui do anim doner. Tempor capicola est chicken ground round hamburger elit pork porchetta. Aliqua leberkas excepteur, brisket nulla chicken eu cow. Culpa shank meatloaf quis in, non consequat ut tongue ham ham hock.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 2,
                    },
                    new Comment {
                        AuthorId = 1,
                        Content = "Lorem pork chop burgdoggen bacon consequat irure, nulla et minim aute laborum. Frankfurter filet mignon pig landjaeger occaecat, id ipsum strip steak capicola deserunt cupim consectetur flank proident venison. Capicola shoulder flank exercitation beef ribs. Burgdoggen est tri-tip, do chuck bresaola ut beef incididunt doner shank sed. Turducken beef ea cow adipisicing velit laboris cupim cillum chicken jowl magna.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 2,
                    },
                    new Comment {
                        AuthorId = 3,
                        Content = "Commodo voluptate reprehenderit meatloaf veniam duis deserunt jowl lorem. Labore ullamco esse duis occaecat tenderloin tri-tip cow. Doner shoulder short ribs est quis burgdoggen, magna pork loin picanha landjaeger non. Cupim in aute, brisket mollit deserunt t-bone chicken alcatra nostrud. Pancetta pork chop dolore veniam in, ribeye excepteur pastrami aute adipisicing consectetur et corned beef. Fugiat short loin jowl, burgdoggen qui chicken biltong magna alcatra occaecat buffalo consequat ullamco. Meatball jowl shank, sed nisi leberkas ullamco ut.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 1,
                    },
                    new Comment {
                        AuthorId = 4,
                        Content = "Ham hock jerky bacon, strip steak labore ham aute velit in ea. Qui alcatra porchetta ex labore venison ipsum brisket jowl sausage dolor commodo. Reprehenderit kielbasa biltong, lorem id andouille shoulder bacon ball tip in pork belly ex anim. Pancetta pork belly sed, frankfurter ullamco do ipsum nisi turducken magna ea pork cupim.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 1,
                    },
                    new Comment {
                        AuthorId = 5,
                        Content = "Pork loin ground round ea sunt turkey cillum strip steak fugiat excepteur beef in. Sunt ground round short loin anim ad. Incididunt sausage ball tip, aute nostrud t-bone doner ullamco. Aliquip hamburger sausage elit. Tongue veniam meatball officia swine fugiat occaecat venison. Officia qui velit laborum veniam, kevin nulla non shoulder tail burgdoggen tri-tip.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 2,
                    },
                    new Comment {
                        AuthorId = 2,
                        Content = "Labore beef id sirloin jerky ut meatloaf pig biltong spare ribs chicken hamburger ham hock nulla ad. Strip steak anim incididunt laborum pariatur venison sint minim ground round. Drumstick brisket leberkas hamburger, doner ullamco irure salami pork chop consequat frankfurter fugiat sunt porchetta andouille. Ribeye culpa shankle ipsum dolore tongue spare ribs ham hock beef ribs. Est pig ipsum, ball tip sirloin frankfurter lorem jowl pastrami cillum ad. Et dolore turkey shoulder.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 8,
                    },
                    new Comment {
                        AuthorId = 4,
                        Content = "Magna minim velit culpa venison aute est pariatur turkey ea porchetta tail filet mignon consequat dolor. Kielbasa porchetta alcatra, anim leberkas pastrami elit. Shoulder dolore labore flank ex nostrud filet mignon sed, swine biltong turkey. Eu exercitation cupidatat flank strip steak.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 20,
                    },
                    new Comment {
                        AuthorId = 2,
                        Content = "Adipisicing shoulder sed shank magna pork loin minim qui, in ham ipsum lorem aliquip. Ball tip labore esse ex culpa pariatur id. Shankle short loin et porchetta, burgdoggen cillum occaecat non ut aliqua aliquip. Ullamco beef ribs anim pork chop bacon.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 17,
                    },
                    new Comment {
                        AuthorId = 1,
                        Content = "Cupidatat shank dolore pariatur, flank hamburger exercitation tenderloin duis dolor kevin ut in picanha salami. Ham labore pork loin drumstick, jowl prosciutto veniam alcatra cillum duis ball tip sint short loin. Cupim do venison dolor prosciutto in tri-tip. Et aute eu picanha tempor consectetur, tenderloin pork aliqua swine kielbasa reprehenderit. Veniam strip steak boudin bresaola.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 17,
                    },
                    new Comment {
                        AuthorId = 5,
                        Content = "Qui ball tip commodo, sunt t-bone leberkas cupidatat pastrami kevin sausage. Capicola chicken excepteur ex venison leberkas beef ribs andouille laboris. Occaecat in alcatra id jerky elit. Fatback do andouille aliqua deserunt burgdoggen anim.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 8,
                    },
                    new Comment {
                        AuthorId = 2,
                        Content = "Fugiat reprehenderit ball tip, ham enim ipsum drumstick. Officia short ribs occaecat bresaola strip steak. Corned beef ut irure do. Ut dolore ut, pig tempor spare ribs salami fatback bresaola rump porchetta jowl aute. Ut tri-tip ut meatloaf strip steak meatball sed laboris ham alcatra. Ipsum sunt fugiat, quis ea minim strip steak beef jerky ad incididunt andouille. Tongue in consectetur elit short loin venison.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 15,
                    },
                    new Comment {
                        AuthorId = 3,
                        Content = "Aliqua commodo laboris salami jerky pork belly ullamco ham hock aute mollit officia. Proident elit excepteur salami, hamburger sausage consequat ribeye ut id ham hock. Aliqua ea fugiat, capicola burgdoggen qui chuck short loin. Corned beef pork loin turducken kevin shank shoulder.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 15,
                    },
                    new Comment {
                        AuthorId = 2,
                        Content = "Frankfurter turducken in, pork loin id corned beef irure quis picanha burgdoggen boudin minim doner. Ullamco proident ham hock cupidatat non elit culpa chicken consequat. Labore consectetur tenderloin, veniam magna pancetta pork loin fatback. Consectetur excepteur picanha laborum beef ribs aliqua, filet mignon veniam biltong proident deserunt jowl. Qui quis salami picanha officia laboris non labore kielbasa swine. Reprehenderit drumstick in pork tenderloin nostrud buffalo pork chop id beef ribs ut corned beef. Doner et swine, minim occaecat pariatur laboris fatback ut picanha duis brisket consequat.",
                        Date = new DateTime (rnd.Next(2017,2018), rnd.Next(1,12), rnd.Next(1,28),rnd.Next(0,23),rnd.Next(0,59),rnd.Next(0,59)),
                        PostId = 1,
                    },
                };
                context.AddRange(list);
                context.SaveChanges();
            }

           
        }
      

    }
}
