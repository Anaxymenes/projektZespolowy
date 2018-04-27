using Data.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IPostHobbyService
    {
        IEnumerable<PostHobby> GetAllByPost(int id);
    }
}
