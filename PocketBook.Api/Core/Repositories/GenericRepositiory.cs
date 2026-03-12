using Microsoft.EntityFrameworkCore;
using PocketBook.Api.Core.IRepositories;
using PocketBook.Api.Data;
using System.Linq.Expressions;

namespace PocketBook.Api.Core.Repositories
{
    public class GenericRepositiory<T> : IGenericRepository<T> where T : class
    {
        private readonly ApiDbContext _context;
        protected DbSet<T> dbSet;
        private readonly ILogger _logger;

        public GenericRepositiory(ApiDbContext dbContext, ILogger logger)
        {
            _context = dbContext;
            _logger = logger;
            dbSet = dbContext.Set<T>();
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public Task<T> GetByAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
