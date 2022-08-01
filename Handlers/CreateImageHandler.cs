using FunnyImages.Commands.Image;
using FunnyImages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Handlers
{
    public class CreateImageHandler : ICommandHandler<CreateImage>
    {
        private readonly IImageService _imageService;
        public CreateImageHandler(IImageService imageService)
        {
            _imageService = imageService;
        }
        public async Task HandleAsync(CreateImage command)
            => await _imageService.UploadAsync(Guid.NewGuid(), command.UserId, 
                        command.Title, command.Description, command.ImageFile);

        // Task UploadAsync(Guid id, Guid userId, string title, string description, IFormFile imageFile);

    }
}
