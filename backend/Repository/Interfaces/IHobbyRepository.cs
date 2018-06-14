using Data.DBModel;
using Data.Edit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IHobbyRepository : IRepository<Hobby> {
        Hobby GetHobby(int id);
        bool Add(Hobby entity);
        Hobby Edit(Hobby hobbyEdit, int userId);
        IQueryable<Hobby> GetAllHobbiesForAccountId(int accountId);
        IQueryable<Hobby> GetAllWithPagination(int countOfItem, int page);
        bool Delete(int hobbyId, int accountId);
    }
}
