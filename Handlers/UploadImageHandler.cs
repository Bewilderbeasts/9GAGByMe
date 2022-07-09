using FunnyImages.Commands.Image;
using FunnyImages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Handlers
{
    public class UploadImageHandler : ICommandHandler<UploadImage>
    {
        private readonly IImageService _imageService;
        public UploadImageHandler(IImageService imageService)
        {
            _imageService = imageService;
        }
        public async Task HandleAsync(UploadImage command)
            => await _imageService.UploadAsync(Guid.NewGuid(), command.UserId, command.Title, command.Description, command.ImageFile);

        // Task UploadAsync(Guid id, Guid userId, string title, string description, IFormFile imageFile);

    }
}
