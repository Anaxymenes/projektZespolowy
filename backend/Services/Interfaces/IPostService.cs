using Data.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetByAuthor(int authorId);
        Post GetById(int id);
    }
}
