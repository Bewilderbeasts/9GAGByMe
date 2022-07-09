using FunnyImages.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Repositories
{
    public interface ICommentRepository
    {
        public Task<Comment> GetAsync(Guid id);
        public Task<IEnumerable<Comment>> GetCorrectAsync(Guid imageId);
        public Task<IEnumerable<Comment>> GetAllAsync();
        public Task AddAsync(Comment comment);
        public Task DeleteAsync(Guid id);
    }
}
