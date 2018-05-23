using Data.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IPictureRepository : IRepository<Picture>
    {
        IEnumerable<Picture> GetByPost(int postId);
    }
}
