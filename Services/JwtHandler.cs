using FunnyImages.DTO;
using FunnyImages.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FunnyImages.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtsettings;
        public JwtHandler(IOptions<JwtSettings> settings)
        {
            _jwtsettings = settings.Value;
        }
        public JwtDto CreateToken(Guid userId, string role)
        {
            var now = DateTimeOffset.UtcNow;

            var expires = now.AddMinutes(_jwtsettings.ExpiryMinutes);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUnixTimeSeconds().ToString(),
                ClaimValueTypes.Integer64),
                };

            var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtsettings.Key ??
                                       throw new InvalidOperationException("IssuerSigningKey is not set"))
            ),
            SecurityAlgorithms.HmacSha256);


            var jwt = new JwtSecurityToken(
            issuer: _jwtsettings.Issuer,
            claims: claims,
            notBefore: now.DateTime,
            expires: expires.DateTime,
            signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                Token = token,
                Expiry = expires.ToUnixTimeMilliseconds()
            };

        }
    }
}
