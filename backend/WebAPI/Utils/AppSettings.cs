using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Utils
{
    public class AppSettings {
        public string Secret { get; set; }
        public string AccessExpireMinutes { get; set; }
        public string RefreshExpireMinutes { get; set; }
    }
}
