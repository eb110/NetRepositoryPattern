using Microsoft.EntityFrameworkCore;
using PocketBook.Api.Models;

namespace PocketBook.Api.Data
{
    public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
    {
        public virtual DbSet<UserPB> UsersPB { get; set; }
    }
}
