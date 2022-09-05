using FunnyImages.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Repositories
{
    public class ImageRepository : IImageRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;
        public ImageRepository(IMongoDatabase database)
        {
            _database = database;
        }
    
        public async Task AddAsync(Image image)
            => await Images.InsertOneAsync(image); 

        public async Task DeleteAsync(Guid id)
                 => await Images.DeleteOneAsync(x => x.Id == id);

        public async Task<IEnumerable<Image>> GetAllAsync()
                => await Images.AsQueryable().ToListAsync();

        public async Task<Image> GetAsync(Guid id)
                 => await Images.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Image> GetAsync(string title)
            => await Images.AsQueryable().FirstOrDefaultAsync(x => x.Title == title);

        private IMongoCollection<Image> Images => _database.GetCollection<Image>("Images");

    }

}

