using Data.DBModels;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IHobbyRepository : IRepository<Hobby>
    {
        IQueryable<Hobby> GetAllHobbiesForIdList(List<int> hobbyIdList);
    }
}
