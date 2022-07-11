using FunnyImages.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Repositories
{
    public interface IVoteRepository
    {
        public Task<Vote> GetAsync(Guid id);
        public Task<Vote> GetAsync(Guid imageId, Guid userId);
        public Task AddAsync(Vote vote);
        public Task ChangeVoteAsync(Guid imageId, Guid userId, int vote);
        public Task DeleteAsync(Guid id);
    }
}
