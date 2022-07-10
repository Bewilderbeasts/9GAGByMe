using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Commands.Comment
{
    public class CreateComment : AuthenticatedCommandBase
    {
        public Guid Id { get;  set; }
        public Guid ImageId { get;  set; }
        public string Content { get; set; }
    }
}
