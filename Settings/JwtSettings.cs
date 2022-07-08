using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Settings
{
    public class JwtSettings
    {
        public string ValidIssuer { get; set; }
        public string IssuerSigningKey { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}
