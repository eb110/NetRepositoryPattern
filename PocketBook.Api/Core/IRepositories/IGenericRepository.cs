using System.Linq.Expressions;

namespace PocketBook.Api.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(Guid id);
        public Task<bool> CreateAsync(T entity);
        public Task<bool> DeleteAsync(Guid id);
        public Task<bool> Update(T entity);
        //where - id or name or other parameters
        public Task<T> GetByAsync(Expression<Func<T, bool>> predicate);

    }
}
