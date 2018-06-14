using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Search
{
    public class SearchDTO {
        public List<AccountDTO> AccountResults { get; set; }
        public List<HobbyDTO> HobbyResults { get; set; }
    }
}
