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
using FunnyImages.Extensions;

namespace FunnyImages.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IUserRepository userRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
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
            var user = await _userRepository.GetOrFailAsync(userId);
            var image = await _imageRepository.GetAsync(title);
            if (image != null)
            {
                throw new Exception("There is an image with same title");
            }
            //public Image(Guid id, string title, string description, IFormFile imageFile, User user)
            image = new Image(id, title, description, imageFile, user);

            await _imageRepository.AddAsync(image);
        }
    }
}
