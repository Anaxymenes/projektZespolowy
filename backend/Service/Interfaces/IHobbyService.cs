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
    }
}
