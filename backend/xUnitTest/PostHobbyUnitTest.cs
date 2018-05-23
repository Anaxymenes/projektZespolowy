using Data.DBModel;
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

        [Fact]
        public void ShouldReturnAllPostHobby() {
            List<Hobby> hobbies = new List<Hobby>() {
                new Hobby() {
                    Id = 1, AdministratorId = 1, Color = "3212", Description="Lorem ipsum", Logo= "logo.png", Name = "Test"
                },
                new Hobby() {
                    Id = 2, AdministratorId = 2, Color = "AA3212", Description="A Lorem ipsum", Logo= "logo2.png", Name = "Bum"
                }
            };
            List<Post> posts = new List<Post>() {
                new Post(){
                    Id=1, AuthorId=1,Content="asdasd",Date=DateTime.Now ,PostTypeId=1
                },
                new Post(){
                    Id=2, AuthorId=2,Content="Test",Date=DateTime.Now ,PostTypeId=1
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
            postHobbyRepository.Setup(x => x.GetAll()).Returns(postHobbyList.AsQueryable());
            var postHobbyService = new PostHobbyService(postHobbyRepository.Object);
            var postHobbyController = new PostHobbyController(postHobbyService);

            List<PostHobby> results = postHobbyController.GetAll();

            Assert.Equal(postHobbyList, results);
        }
    }

    

    

    

    

    
}
