using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Comment Edit(Comment entity, int userId);
        bool Delete(int id, int userId);
    }
}
