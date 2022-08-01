using FunnyImages.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

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



        //private static ISet<Image> _images = new HashSet<Image>();

        //public async Task AddAsync(Image image)
        //{
        //    _images.Add(image);
        //    await Task.CompletedTask;
        //}

        //public async Task DeleteAsync(Guid id)
        //{
        //    var image = await GetAsync(id);
        //    _images.Remove(image);
        //    await Task.CompletedTask;
        //}

        //public async Task<IEnumerable<Image>> GetAllAsync()
        //    => await Task.FromResult(_images);


        //public async Task<Image> GetAsync(Guid id)
        //        => await Task.FromResult( _images.SingleOrDefault(x => x.Id == id));


        //public async Task<Image> GetAsync(string title)
        //        => await Task.FromResult(_images.SingleOrDefault(x => x.Title == title));
    }

}

