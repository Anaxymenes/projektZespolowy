using Data.DBModel;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IPostHobbyService {
        List<PostHobby> GetAll();
        void CreatePostHobby(PostDTO postDTO);
        List<PostDTO> GetAllPostsByHobbyId(int hobbyId);
    }
}
