using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Utils
{
    public class ClaimsMethods {
        static public List<ClaimDTO> GetClaimsList(IEnumerable<Claim> claims) {
            List<ClaimDTO> resutl = new List<ClaimDTO>();
            foreach (var claim in claims)
                resutl.Add(new ClaimDTO { Type = claim.Type.Substring(claim.Type.LastIndexOf("/") + 1), Value = claim.Value });
            return resutl;
        }
    }
}
