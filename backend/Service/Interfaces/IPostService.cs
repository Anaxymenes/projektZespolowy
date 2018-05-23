using Data.DBModel;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IPostService
    {
        Post Add(PostDTO post);
        void Test(Post post);
    }
}
