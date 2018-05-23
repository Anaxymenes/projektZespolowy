using Data.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
<<<<<<< HEAD
    public interface IPostHobbyRepository : IRepository<PostHobby>
    {
        IQueryable<PostHobby> GetAllPostByHobbyId(int v);
=======
    public interface IPostHobbyRepository : IRepository<PostHobby> {
        IQueryable<PostHobby> GetAllByPost(int postId);
>>>>>>> parent of 907ef6e... Many changes
    }
}
