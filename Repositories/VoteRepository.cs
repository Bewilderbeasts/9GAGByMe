using FunnyImages.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private static ISet<Vote> _votes = new HashSet<Vote>();

        public async Task AddAsync(Vote vote)
        {
            _votes.Add(vote);
            await Task.CompletedTask;
        }

        public async Task ChangeVoteAsync(Guid imageId, Guid userId, int vote)
        {
            var oldVote = _votes.FirstOrDefault(x => x.ImageId == imageId && x.UserId == userId);

            var voteId = oldVote.Id;
            var voted = await GetAsync(voteId);

            if (voted.Votes == -1 && vote == -1)
            {
                voted.Votes = -1;
            }
            else if (voted.Votes == -1 && vote == 1)
            {
                voted.Votes = 1;
            }
            else if (voted.Votes == 1 && vote == 1)
            {
                voted.Votes = 1;
            }
            else if (voted.Votes == 1 && vote == -1)
            {
                voted.Votes = -1;
            }

            //saving the changgges
            //_votes.SaveChanges(vote);

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var vote = await GetAsync(id);
            _votes.Remove(vote);
            await Task.CompletedTask;
        }

        public async Task<Vote> GetAsync(Guid id)
              => await Task.FromResult(_votes.SingleOrDefault(x => x.Id == id));

        public async Task<Vote> GetAsync(Guid imageId, Guid userId)
            => await Task.FromResult(_votes.FirstOrDefault(x => x.ImageId == imageId && x.UserId == userId));
    }
}
