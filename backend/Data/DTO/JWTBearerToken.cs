using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class JWTBearerToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
