using Data.DBModels;
using Moq;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
    
    public  class PostController {
        private PostService _service;

        public PostController(PostService service) {
            _service = service;
        }

        public IEnumerable<Post> GetAll() {
            return _service.GetAll();
        }
    }

    public class PostService {
        private IRepository<Post> _repository;

        public PostService(IRepository<Post> repository) {
            _repository = repository;
        }

        public IEnumerable<Post> GetAll() {
            return _repository.GetAll().AsEnumerable();
        }
    }
}
