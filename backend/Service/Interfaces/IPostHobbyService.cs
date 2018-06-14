using Data.DBModel;
using Data.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPostHobbyService {
        Task<string> UploadFile(IFormFile file);
        List<PostDTO> GetAll();
        List<PostDTO> GetAllPostsByHobbyId(int hobbyId);
        void CreatePostHobby(PostAdd postAdd, List<ClaimDTO> list);
        List<PostDTO> GetAllPostsByUserHobbys(List<ClaimDTO> list);
        List<PostDTO> GetAllPostByAuthorId(int authorId);
        bool Delete(int postId, List<ClaimDTO> list);
    }
}
