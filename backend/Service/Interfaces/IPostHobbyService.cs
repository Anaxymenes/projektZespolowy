using Data.DBModel;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IPostHobbyService {
        List<PostHobby> GetAll();
        //List<PostDTO> GetAllPostsByHobbyId(int id);
    }
}
