using Data.DBModels;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IHobbyRepository : IRepository<Hobby>
    {
        List<PostHobby> GetAllHobbiesByPost(List<int> postIdList);
    }
}
