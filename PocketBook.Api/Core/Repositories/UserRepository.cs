using Microsoft.EntityFrameworkCore;
using PocketBook.Api.Core.IRepositories;
using PocketBook.Api.Data;
using PocketBook.Api.Models;

namespace PocketBook.Api.Core.Repositories
{
    public class UserRepository(ApiDbContext context, ILogger logger) 
        : GenericRepositiory<UserPB>(context, logger), IUserRepository
    {
        public Task<string> GetFullName(Guid id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<UserPB>> GetAllAsync()
        {
            var check = await dbSet.ToListAsync();
            return new List<UserPB>();
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);

            if(user == null)
            {
                logger.LogError($"user of id {id} does not exist in db");
                return false;
            }

            dbSet.Remove(user);

            return true;
        }
    }
}
