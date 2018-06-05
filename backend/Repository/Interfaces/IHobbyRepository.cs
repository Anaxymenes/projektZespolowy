using Data.DBModel;
using Data.Edit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IHobbyRepository : IRepository<Hobby> {
        Hobby GetHobby(int id);
        bool Add(Hobby entity);
        Hobby Edit(Hobby hobbyEdit, int userId);
    }
}
