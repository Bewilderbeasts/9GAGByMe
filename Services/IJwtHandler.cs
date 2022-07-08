using FunnyImages.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Services
{
    public interface IJwtHandler
    {
      JwtDto CreateToken(Guid userId, string role);
    }
}
