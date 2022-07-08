using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
       Guid UserId { get; set; }
    }
}
