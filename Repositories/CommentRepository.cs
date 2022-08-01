using FunnyImages.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace FunnyImages.Repositories
{
    public class CommentRepository : ICommentRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public CommentRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Comment comment)
            => await Comments.InsertOneAsync(comment);

        public async Task DeleteAsync(Guid id)
                 => await Comments.DeleteOneAsync(x => x.Id == id);

        public async Task<IEnumerable<Comment>> GetAllAsync()
                => await Comments.AsQueryable().ToListAsync();

        public async Task<Comment> GetAsync(Guid id)
                 => await Comments.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Comment>> GetCorrectAsync(Guid imageId)
            => await Comments.AsQueryable().Where(x => x.ImageId == imageId).ToListAsync();

        private IMongoCollection<Comment> Comments => _database.GetCollection<Comment>("Comments");
    
        //private static ISet<Comment> _comments = new HashSet<Comment>();
        //public async Task AddAsync(Comment comment)
        //{
        //    _comments.Add(comment);
        //    await Task.CompletedTask;
        //}

        //public async Task DeleteAsync(Guid id)
        //{
        //    var comment = await GetAsync(id);
        //    _comments.Remove(comment);
        //    await Task.CompletedTask;
        //}

        //public async Task<IEnumerable<Comment>> GetAllAsync()
        //    => await Task.FromResult(_comments);

        //public async Task<Comment> GetAsync(Guid id)
        //    => await Task.FromResult(_comments.FirstOrDefault(x => x.Id == id));

        //public async Task<IEnumerable<Comment>> GetCorrectAsync(Guid imageId)
        //    => await Task.FromResult(_comments.Where(x => x.ImageId == imageId));


    }
}
