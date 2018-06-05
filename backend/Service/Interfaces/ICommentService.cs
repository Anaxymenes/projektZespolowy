using Data.Add;
using Data.DBModel;
using Data.DTO;
using Data.EditViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ICommentService
    {
        void Delete(int id, int accountId);
        CommentDTO Add(CommentAdd commentDto, List<ClaimDTO> list);
        CommentDTO Edit(CommentEditV2 commentEdit, List<ClaimDTO> list);
    }
}
