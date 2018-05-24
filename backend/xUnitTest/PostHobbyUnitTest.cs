using Data.DBModel;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Repository.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Controllers;
using Xunit;

namespace xUnitTest
{
    public class PostHobbyUnitTest
    {

        /*
        [Fact]
        public void ShouldReturnAllPostHobby() {
            List<Account> accounts = new List<Account>()
            {
                new Account()
                {
                    Id=1,
                    Username = "Kowal"
                },
                new Account()
                {
                    Id=2,
                    Username = "Nowacki"
                }
            };
            List<Hobby> hobbies = new List<Hobby>() {
                new Hobby() {
                    Id = 1, AdministratorId = 1, Color = "3212", Description="Lorem ipsum", Logo= "logo.png", Name = "Test"
                },
                new Hobby() {
                    Id = 2, AdministratorId = 2, Color = "AA3212", Description="A Lorem ipsum", Logo= "logo2.png", Name = "Bum"
                }
            };
            List<Comment> comments = new List<Comment>()
            {
                new Comment()
                {
                    Id=1, Author = accounts.First(x=>x.Id==1), Content="First comment", Date=DateTime.Now
                },
                new Comment()
                {
                    Id=2, Author = accounts.First(x=>x.Id==1), Content="Second comment", Date=DateTime.Now
                }
            };
            List<Post> posts = new List<Post>() {
                new Post(){
                    Id=1, AuthorId=1,Content="asdasd",Date=DateTime.Now ,PostTypeId=1, Comments = comments
                },
                new Post(){
                    Id=2, AuthorId=2,Content="Test",Date=DateTime.Now ,PostTypeId=1, Comments = comments
                }
            };
            List<PostHobby> postHobbyList = new List<PostHobby>() {
                new PostHobby() {
                    Id = 1, HobbyId = 1, PostId = 1
                },
                new PostHobby() {
                    Id = 2, HobbyId = 2, PostId = 2
                }
            };

            var postHobbyRepository = new Mock<IPostHobbyRepository>();
            var postRepository = new Mock<IPostRepository>();
            postHobbyRepository.Setup(x => x.GetAll()).Returns(postHobbyList.AsQueryable());
            postRepository.Setup(x => x.GetAll()).Returns(posts.AsQueryable());
            var postService = new PostService(postRepository);
            var postHobbyService = new PostHobbyService(postHobbyRepository.Object, postRepository.Object);
            var postHobbyController = new PostHobbyController(postHobbyService);

            List<PostHobby> results = postHobbyController.GetAll();

            Assert.Equal(postHobbyList, results);
        }*/
        
        //[Fact]
        //public void ShouldReturnPostsByHobby()
        //{
        //    List<Hobby> hobbies = new List<Hobby>() {
        //        new Hobby() {
        //            Id = 1, AdministratorId = 1, Color = "3212", Description="Lorem ipsum", Logo= "logo.png", Name = "Test"
        //        },
        //        new Hobby() {
        //            Id = 2, AdministratorId = 2, Color = "AA3212", Description="A Lorem ipsum", Logo= "logo2.png", Name = "Bum"
        //        }
        //    };
        //    List<Account> accounts = new List<Account>()
        //    {
        //        new Account()
        //        {
        //            Id=1,
        //            Username = "Kowalski"
        //        },
        //        new Account()
        //        {
        //            Id=2,
        //            Username = "Nowak"
        //        }
        //    };
        //    List<Post> posts = new List<Post>() {
        //        new Post(){
        //            Id=1,
        //            AuthorId =1,
        //            Author = accounts.First(x=>x.Id==1),
        //            Content ="asdasd",
        //            Date =DateTime.Now,
        //            PostTypeId =1
        //        },
        //        new Post(){
        //            Id=2,
        //            AuthorId =2,
        //            Author = accounts.First(x=>x.Id==2),
        //            Content ="Test",
        //            Date =DateTime.Now ,
        //            PostTypeId =1
        //        }
        //    };

           
        //    List<PostHobby> postHobbyList = new List<PostHobby>() {
        //        new PostHobby() {
        //            Id = 1,
        //            HobbyId = 1,
        //            PostId = 1,
        //            Hobby =hobbies.First(x=>x.Id==1),
        //            Post =posts.First(x=>x.Id==1)
        //        },
        //        new PostHobby() {
        //            Id = 2,
        //            HobbyId = 2,
        //            PostId = 2,
        //            Hobby =hobbies.First(x=>x.Id==2),
        //            Post =posts.First(x=>x.Id==2)
        //        }
        //    };

        //    List<PostDTO> postHobbyByIdList = new List<PostDTO>() {
        //        new PostDTO() {
        //            Content = posts.First(x=>x.Id==1).Content,
        //            PostType ="a",
        //            Author = postHobbyList.First(x=>x.Id==1).Post.Author.Username,
        //            Date=postHobbyList.First(x=>x.Id==1).Post.Date
        //        },
        //        new PostDTO() {
        //            Content = posts.First(x=>x.Id==2).Content,
        //            PostType ="b",
        //            Author = postHobbyList.First(x=>x.Id==1).Post.Author.Username,
        //            Date=postHobbyList.First(x=>x.Id==2).Post.Date
        //        }
        //    };

        //    var postHobbyByIdRepository = new Mock<IPostHobbyRepository>();
        //    postHobbyByIdRepository.Setup(x=>x.GetAllPostByHobbyId(1)).Returns(postHobbyList.AsQueryable);
        //    var postHobbyService = new PostHobbyService(postHobbyByIdRepository.Object);
        //    var postHobbyController = new PostHobbyController(postHobbyService);

        //    List<PostDTO> results = PostHobbyController.GetAllPostsByHobbyId(1);




        //}
    }

    

    

    

    

    
}
