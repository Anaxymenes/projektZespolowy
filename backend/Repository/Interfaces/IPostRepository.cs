using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        IQueryable GetPost(int id);
        IQueryable<Post> GetAllPostByHobbyId(int hobbyId);
    }
}
