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
        private readonly IHobbyRepository _hobbyRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRespository,
                           IHobbyRepository hobbyRepository,
                           IMapper mapper)
        {
            _postRespository = postRespository;
            _hobbyRepository = hobbyRepository;
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


        public List<PostDTO> GetAllPostByAuthorId(int authorId) {
            try {
                List<PostDTO> results = new List<PostDTO>();
                foreach (var result in _postRespository.GetAllPostByAuthorId(authorId)) {
                    PostDTO post = _mapper.Map<PostDTO>(result);
                    post.Hobbys = this.GetAllHobbyForPostDTOFromPost(result);
                    post.Pictures = this.GetAllPicturesForPostDTO(result);
                    results.Add(post);
                }
                return results;
            }catch (Exception e) {
                return null;
            }
        }

        public List<PostDTO> GetAllPostsByHobbyId(int hobbyId) {
            var resultDb = _postRespository.GetAllPostByHobbyId(hobbyId);
            List<PostDTO> resultList = new List<PostDTO>();
            
            foreach (var result in resultDb) {
                PostDTO post = _mapper.Map<PostDTO>(result);
                post.Hobbys = this.GetAllHobbyForPostDTOFromPost(result);
                post.Pictures = this.GetAllPicturesForPostDTO(result);
                resultList.Add(post);
            }
                
            return resultList;
        }

        public List<PostDTO> GetAllPostsByUserHobbys(List<ClaimDTO> claimsList)
        {
            int userId = Convert.ToInt32(claimsList.Find(x => x.Type == "nameidentifier").Value);
            IQueryable<Hobby> userHobbys = _hobbyRepository.GetAllHobbiesForAccountId(userId);
            List<int> hobbysId = new List<int>();
            foreach(var hobby in userHobbys)
            {
                hobbysId.Add(hobby.Id);
            }
            List<PostDTO> result = new List<PostDTO>();
            foreach(var hobbyId in hobbysId)
            {
                var posts = _postRespository.GetAllPostByHobbyId(hobbyId);
                foreach(var post in posts)
                {
                    PostDTO postResult = _mapper.Map<PostDTO>(post);
                    postResult.Hobbys = this.GetAllHobbyForPostDTOFromPost(post);
                    postResult.Pictures = this.GetAllPicturesForPostDTO(post);
                    result.Add(postResult);
                }
            }
            List<PostDTO> sortedResult = result.OrderByDescending(o => o.Date).ToList();
            return sortedResult;
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

        public List<PostDTO> GetAll()
        {
            var result = _postRespository.GetAll();
            if (result == null || result.Count() == 0)
                return null;
            List<PostDTO> list = new List<PostDTO>();
            foreach (var obj in result)
            {
                var postDTO = _mapper.Map<PostDTO>(obj);
                postDTO.Hobbys = this.GetAllHobbyForPostDTOFromPost(obj);
                list.Add(postDTO);
            }
            return list;
        }

        protected List<HobbyForPostDTO> GetAllHobbyForPostDTOFromPost(Post post) {
            HashSet<HobbyForPostDTO> hobbies = new HashSet<HobbyForPostDTO>();
            foreach (var hobby in post.PostHobbies)
                hobbies.Add(_mapper.Map<HobbyForPostDTO>(hobby));
            return hobbies.ToList();
        }

        protected List<string> GetAllPicturesForPostDTO (Post post) {
            List<string> pictures = new List<string>();
            if (post.Pictures != null)
                foreach (var picture in post.Pictures)
                    pictures.Add(picture.Path);
            return pictures;
        }
    }
}
