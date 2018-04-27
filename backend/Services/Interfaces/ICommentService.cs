using Data.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAllForPost(int postId);
        void Add(string content);
        void Delete(int commentId);
        void Update(int commentId, string content);
    }
}
