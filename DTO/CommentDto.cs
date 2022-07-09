using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.DTO
{
    public class CommentDto
    {
        public Guid Id { get; protected set; }
        public Guid ImageId { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Content { get; set; }
    }
}
