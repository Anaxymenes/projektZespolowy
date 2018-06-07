using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IPictureRepository : IRepository<Picture>
    {
        bool AddAll(List<Picture> entities);
    }
}
