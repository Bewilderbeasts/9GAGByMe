using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Settings
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Key { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}
