using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        void Delete(int id, int accountId);
        Comment Edit(Comment comment, int accountId);
    }
}
