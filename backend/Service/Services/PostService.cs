using AutoMapper;
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
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRespository,
                           IMapper mapper)
        {
            _postRespository = postRespository;
            _mapper = mapper;
        }
        
        public Post Add(PostDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);

            //if (postDTO.Pictures == null && postDTO.Event == null)
            //{
                post.PostTypeId = 1;
            //}
            return _postRespository.Add(post);
        }

        public void Delete(int id)
        {
            _postRespository.Delete(id);
        }

        public List<PostDTO> GetAllPostsByHobbyId(int hobbyId) {
            var resultDb = _postRespository.GetAllPostByHobbyId(hobbyId);
            List<PostDTO> resultList = new List<PostDTO>();
            
            foreach (var result in resultDb) {
                HashSet<HobbyForPostDTO> hobbies = new HashSet<HobbyForPostDTO>();
                foreach (var hobby in result.PostHobbies)
                    //hobbies.Add(new HobbyForPostDTO {
                    //    Color = hobby.Hobby.Color,
                    //    Name = hobby.Hobby.Name,
                    //    Id = hobby.Hobby.Id
                    //});
                    hobbies.Add(_mapper.Map<HobbyForPostDTO>(hobby));
                List<string> pictures = new List<string>();
                if (result.Pictures != null)
                    foreach (var picture in result.Pictures)
                        pictures.Add(picture.Path);
                PostDTO post = _mapper.Map<PostDTO>(result);
                post.Hobbys = hobbies.ToList();
                post.Pictures = pictures;
                resultList.Add(post);
            }
                
            return resultList;
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
