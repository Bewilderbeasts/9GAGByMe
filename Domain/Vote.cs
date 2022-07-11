using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Domain
{
    public class Vote
    {
        public Guid Id { get; protected set; }
        public Guid ImageId { get; protected set; }
        public Guid UserId { get; protected set; }
        public int Votes { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Vote()
        {

        }

        public Vote(Guid id, Guid imageId, Guid userId, int votes)
        {
            Id = id;
            ImageId = imageId;
            UserId = userId;
            Votes = votes;
        }
    }
}
