using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Commands.Vote
{
    public class CreateVote : AuthenticatedCommandBase
    {
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
        public int Vote { get; set; }
    }
}
