using Data.DBModel;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Interfaces
{
    public interface IPostService
    {
        Post Add(PostDTO post);
        void Test(Post post);
        void Delete(int id);
        PostDTO GetPost(int id);
        List<Post> GetPosts();
    }
}
