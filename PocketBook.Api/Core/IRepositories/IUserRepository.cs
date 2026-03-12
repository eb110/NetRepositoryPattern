using PocketBook.Api.Models;

namespace PocketBook.Api.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<UserPB>
    {
        //non generic custom function
        public Task<string> GetFullName(Guid id);
    }
}
