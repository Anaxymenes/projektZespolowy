using Data.DBModel;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IPictureService {
        bool AddPictures(PostAdd postAdd, Post post);
        Picture Add(PostAdd postAdd, Post post);
    }
}
