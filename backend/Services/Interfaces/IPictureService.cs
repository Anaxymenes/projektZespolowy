using Data.DBModels;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IPictureService
    {
        IEnumerable<PictureDTO> GetByPost(int postId);
    }
}
