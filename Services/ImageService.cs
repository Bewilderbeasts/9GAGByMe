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
        private readonly IVoteRepository _voteRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IUserRepository userRepository,
            IVoteRepository voteRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _voteRepository = voteRepository;
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

        public async Task VoteAsync(Guid id, Guid imageId, Guid userId, int vote)
        {
            //var user = await _userRepository.GetOrFailAsync(userId);
            var image = await _imageRepository.GetAsync(imageId);
            var oldVote = await _voteRepository.GetAsync(imageId, userId);
            if (oldVote != null)
            {
                await _voteRepository.ChangeVoteAsync(imageId, userId, vote);
                if (vote == 1)
                {
                    image.Rating += 1;
                }
                else { image.Rating -= 1; };

                //zapisanie zmian w DB
                //await _imageRepository.SaveChanges();
                 
            } else { 
            var newVote = new Vote(id, imageId, userId, vote);
            await _voteRepository.AddAsync(newVote);
            if (vote == 1)
            {
                image.Rating += 1;
            } else { image.Rating -= 1; };

                //zapisanie zmian w DB
                //await _imageRepository.SaveChanges();
            }
            await Task.CompletedTask;
        }


    }
}
