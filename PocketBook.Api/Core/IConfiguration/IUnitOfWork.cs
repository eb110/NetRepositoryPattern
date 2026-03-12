using PocketBook.Api.Core.IRepositories;

namespace PocketBook.Api.Core.IConfiguration
{
    //connection point for all entities interfaces
    //right now just one
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }

        public Task CompleteAsync();
    }
}
