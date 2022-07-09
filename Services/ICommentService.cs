using FunnyImages.Domain;
using FunnyImages.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Services
{
    public interface ICommentService : IService
    {
        public Task<CommentDto> GetAsync(Guid id);
        public Task<IEnumerable<CommentDto>> GetImageCommentsAsync(Guid imageId);
        public Task AddAsync(Guid id, Guid userId, Guid imageId, string content);
    }
}
