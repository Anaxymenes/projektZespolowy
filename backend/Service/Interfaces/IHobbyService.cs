using Data.DBModel;
using Data.DTO;
using Data.Edit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Interfaces
{
    public interface IHobbyService {
        List<Hobby> GetAll();
        Hobby Add(HobbyDTO hobby);
        void Delete(int id, int accountId);
        Hobby Edit(HobbyEdit hobbyEdit);
        Hobby Get(int id);
    }
}
