using System;
using System.Collections.Generic;
using System.Text;
using Data.DTO;

namespace Service.Interfaces
{
    public interface IAccountHobbyService
    {
        bool JoinToGroup(int hobbyId, List<ClaimDTO> list);
        bool leaveGroup(int hobbyId, List<ClaimDTO> list);
    }
}
