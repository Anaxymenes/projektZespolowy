using Data.DBModels;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostDTO> GetAll();
        IEnumerable<Post> GetByAuthor(int authorId);
        Post GetById(int id);
    }
}
