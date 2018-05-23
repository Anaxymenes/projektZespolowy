using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IPostHobbyRepository : IRepository<PostHobby>
    {
        IQueryable<PostHobby> GetAllPostByHobbyId(int v);
    }
}
