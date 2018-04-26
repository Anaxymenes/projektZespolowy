using Data.DBModels;
using Moq;
using Repository.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Controllers;
using Xunit;

namespace UnitTest
{
    public class PostUnitTest{

        [Fact]
        public void ShouldReturnAllPosts (){
            var role = new Role() { Id = 1, Name = "User" };
            var postType = new PostType() { Id = 1, Name = "Normal" };
            DateTime date = DateTime.Now;
            var author = new Account() {
                Id = 1,
                Active = true,
                Email = "test@test.pl",
                Password = "1234",
                PasswordSalt = "231",
                Role = role,
                Username = "Tester"
            };
            var postList = new List<Post>() {
                new Post {
                    Id = 1, Author = author, Content = "asd",
                    Date = date, PostType = postType
                },
                new Post {
                    Id = 2, Author = author, Content = "asd2",
                    Date = date, PostType = postType
                }
            };

            var _repository = new Mock<IRepository<Post>>();
            _repository.Setup(x => x.GetAll()).Returns(postList.AsQueryable());
            var _service = new PostService(_repository.Object);
            var _controller = new PostController(_service);

            var results = _controller.GetAll();

            Assert.Equal(postList.AsEnumerable(), results);
        }

        [Fact]
        public void ShouldReturnPostByAuthor()
        {
            var role = new Role() { Id = 1, Name = "User" };
            var postType = new PostType() { Id = 1, Name = "Normal" };
            DateTime date = DateTime.Now;
            var author = new Account()
            {
                Id = 1,
                Active = true,
                Email = "test@test.pl",
                Password = "1234",
                PasswordSalt = "231",
                Role = role,
                Username = "Tester"
            };

            var postList = new List<Post>() {
                new Post {
                    Id = 1, Author = author, Content = "asd",
                    Date = date, PostType = postType
                },
                new Post {
                    Id = 2, Author = author, Content = "asd2",
                    Date = date, PostType = postType
                }
            };

            var _repository = new Mock<IRepository<Post>>();
            _repository.Setup(x => x.FindAll(y => y.Author.Id == author.Id)).Returns(postList.ToList());
            var _service = new PostService(_repository.Object);
            var _controller = new PostController(_service);

            var result = _controller.GetByAuthor(author.Id);

            Assert.Equal(postList.AsEnumerable(), result);
        }

        [Fact]
        public void ShouldReturnPostById()
        {
            var role = new Role() { Id = 1, Name = "User" };
            var postType = new PostType() { Id = 1, Name = "Normal" };
            DateTime date = DateTime.Now;
            var author = new Account()
            {
                Id = 1,
                Active = true,
                Email = "test@test.pl",
                Password = "1234",
                PasswordSalt = "231",
                Role = role,
                Username = "Tester"
            };

            var post = new Post() {                
                    Id = 1, Author = author, Content = "asd2",
                    Date = date, PostType = postType
            };

            var _repository = new Mock<IRepository<Post>>();
            _repository.Setup(x => x.Get(1)).Returns(post);
            var _service = new PostService(_repository.Object);
            var _controller = new PostController(_service);

            var result = _controller.GetById(1);

            Assert.Equal(post, result);
        }

    }




}
