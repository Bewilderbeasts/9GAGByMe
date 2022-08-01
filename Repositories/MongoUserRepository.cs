using FunnyImages.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Repositories
{
    public class MongoUserRepository : IUserRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;
        public MongoUserRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<User> GetAsync(Guid id)
               => await Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string email)
                => await Users.AsQueryable().FirstOrDefaultAsync(x => x.Email == email);

        public async Task<IEnumerable<User>> GetAllAsync()
                => await Users.AsQueryable().ToListAsync();

        public async Task AddAsync(User user)
                => await Users.InsertOneAsync(user);

        public async Task DeleteAsync(Guid id)
                => await Users.DeleteOneAsync(x => x.Id == id);

        public async Task UpdateAsync(User user)
                => await Users.ReplaceOneAsync(x => x.Id == user.Id, user);

        private IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    }
}
