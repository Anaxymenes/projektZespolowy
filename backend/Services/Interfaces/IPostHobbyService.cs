using Data.DBModels;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IPostHobbyService
    {
        IEnumerable<PostHobbyDTO> GetAllByPost(int postId);
    }
}
