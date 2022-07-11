using FunnyImages.Commands.Vote;
using FunnyImages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Handlers
{
    public class CreateVoteHandler : ICommandHandler<CreateVote>
    {
        private readonly IImageService _imageService ;
        public CreateVoteHandler(IImageService imageService)
        {
            _imageService = imageService;
        }
        public async Task HandleAsync(CreateVote command)
                => await _imageService.VoteAsync(Guid.NewGuid(), command.UserId, command.ImageId, command.Vote);
    }
}
