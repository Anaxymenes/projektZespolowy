using Data.DBModel;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ICommentService
    {
        Comment Add(CommentDTO comment);
        void Delete(int id, int accountId);
    }
}
