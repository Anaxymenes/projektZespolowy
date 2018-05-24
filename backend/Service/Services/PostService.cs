using Data.DBModel;
using Data.DTO;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRespository;

        public PostService(IPostRepository postRespository)
        {
            _postRespository = postRespository;
        }
        
        public Post Add(PostDTO postDTO)
        {
            Post post = new Post { };
            post.AuthorId = postDTO.AuthorId;
            post.Date = DateTime.Now;
            post.Content = postDTO.Content;

            if (postDTO.Pictures == null && postDTO.Event == null)
            {
                post.PostTypeId = 1;
            }
            return _postRespository.Add(post);
        }

        public void Delete(int id)
        {
            _postRespository.Delete(id);
        }

        public PostDTO GetPost(int id)
        {
            var results = _postRespository.GetPost(id);
            PostDTO post = new PostDTO()
            {
                //post.Author = results.
            };
            return post;
        }

        public List<Post> GetPosts()
        {
            return _postRespository.GetAll().ToList();
        }

        public void Test(Post post)
        {
            _postRespository.Add(post);
        }
    }
}
