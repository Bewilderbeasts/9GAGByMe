using FunnyImages.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetAsync(Guid id);
        public Task<User> GetAsync(string email);
        public Task<IEnumerable<User>> GetAllAsync();
        public Task AddAsync(User user);
        public Task UpdateAsync(User user);
        public Task DeleteAsync(Guid id);
    }
}
