using Data.DBModel;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IHobbyService {
        List<Hobby> GetAll();
        Hobby Add(HobbyDTO hobby);
        void Delete(int id, int accountId);
        void Edit(string name, string color, int id, int accountId, int newAdminId);
    }
}
