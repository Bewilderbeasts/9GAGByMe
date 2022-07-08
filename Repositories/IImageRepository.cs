using FunnyImages.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Repositories
{
    public interface IImageRepository
    {
        Task<Image> GetAsync(Guid id);
        Task<Image> GetAsync(string title);
        Task<IEnumerable<Image>> GetAllAsync();
        Task AddAsync(Image image);
        Task DeleteAsync(Guid id);
    }
}
