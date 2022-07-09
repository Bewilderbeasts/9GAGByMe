using FunnyImages.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private static ISet<Comment> _comments = new HashSet<Comment>();
        public async Task AddAsync(Comment comment)
        {
            _comments.Add(comment);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var comment = await GetAsync(id);
            _comments.Remove(comment);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
            => await Task.FromResult(_comments);

        public async Task<Comment> GetAsync(Guid id)
            => await Task.FromResult(_comments.FirstOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Comment>> GetCorrectAsync(Guid imageId)
            => await Task.FromResult(_comments.Where(x => x.ImageId == imageId));
    }
}
