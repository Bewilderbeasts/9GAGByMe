using FunnyImages.Domain;
using FunnyImages.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Extensions
{
        public static class RepositoryExtensions
        {
            public static async Task<User> GetOrFailAsync(this IUserRepository repository, Guid userId)
            {
                var user = await repository.GetAsync(userId);
                if (user == null)
                {
                    throw new Exception( $"User with id: {userId} was not found.");
                }
                return user;
            }
        }
    
}
