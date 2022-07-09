using FunnyImages.Commands.Comment;
using FunnyImages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Handlers
{
    public class AddCommentHandler : ICommandHandler<CreateComment>
    {
        private readonly ICommentService _commentService;
        public AddCommentHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public Task HandleAsync(CreateComment command)
                => _commentService.AddAsync(Guid.NewGuid(), command.UserId, command.ImageId, command.Content);
    }
}
