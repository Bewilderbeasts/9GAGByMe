using AutoMapper;
using FunnyImages.Domain;
using FunnyImages.DTO;
using FunnyImages.Extensions;
using FunnyImages.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IImageRepository imageRepository, IUserRepository userRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _imageRepository = imageRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(Guid id, Guid userId, Guid imageId, string content)
        {
            //public Comment(Guid id, string content, User user, Image image)
            var user = await _userRepository.GetOrFailAsync(userId);
            var image = await _imageRepository.GetAsync(imageId);
            //adding image to repo
            var comment = new Comment(id, content, user, image);

            await Task.FromResult(_commentRepository.AddAsync(comment));
        }

        public async Task<CommentDto> GetAsync(Guid id)
        {
            var comment = await _commentRepository.GetAsync(id);

            return _mapper.Map<Comment, CommentDto>(comment);

        }

        public async  Task<IEnumerable<CommentDto>> GetImageCommentsAsync(Guid imageId)
        {
            //var image = await _imageRepository.GetAsync(imageId);
            var comments = await _commentRepository.GetCorrectAsync(imageId);

            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(comments);
        }
    }
}
