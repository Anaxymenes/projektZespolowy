using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IPostHobbyService {
        List<PostHobby> GetAll();
    }
}
