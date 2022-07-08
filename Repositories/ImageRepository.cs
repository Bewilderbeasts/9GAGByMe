using FunnyImages.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private static ISet<Image> _images = new HashSet<Image>();

        public async Task AddAsync(Image image)
        {
            _images.Add(image);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var image = await GetAsync(id);
            _images.Remove(image);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
            => await Task.FromResult(_images);
        

        public async Task<Image> GetAsync(Guid id)
                => await Task.FromResult( _images.SingleOrDefault(x => x.Id == id));


        public async Task<Image> GetAsync(string title)
                => await Task.FromResult(_images.SingleOrDefault(x => x.Title == title));
    }

}

