using FunnyImages.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Services
{
    public interface IImageService : IService
    {
        Task UploadAsync(Guid id, Guid userId, string title, string description, IFormFile imageFile);
        //get file format from the file itself
        Task<ImageDto> GetAsync(Guid imageId);
        Task<ImageDto> GetAsync(string title);
        Task<IEnumerable<ImageDto>> GetAllAsync();
    }
}
