using AutoMapper;
using FunnyImages.Domain;
using FunnyImages.DTO;
using FunnyImages.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FunnyImages.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ImageDto>> GetAllAsync()
        {
            var image = await _imageRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Image>, IEnumerable<ImageDto>>(image);
        }


        public async Task<ImageDto> GetAsync(Guid imageId)
        {
            var image = await _imageRepository.GetAsync(imageId);

            return _mapper.Map<Image, ImageDto>(image);
        }
                

        public async Task<ImageDto> GetAsync(string title)
        {
            var image = await _imageRepository.GetAsync(title);

            return _mapper.Map<Image, ImageDto>(image);
        }


        public async Task UploadAsync(Guid id, Guid userId, string title, string description, IFormFile imageFile)
        {
            var image = await _imageRepository.GetAsync(title);
            if (image != null)
            {
                throw new Exception("There is an image with same title");
            }
            image = new Image(id, userId, title, description, imageFile.FileName.ToString(), imageFile);
            await _imageRepository.AddAsync(image);
        }
    }
}
