using Microsoft.EntityFrameworkCore;

namespace ApiTienda.Models
{
    public class ContextUser : DbContext
    {
        public ContextUser(DbContextOptions<ContextUser> options)
        : base(options)
        {
        }

        public DbSet<User> TodoItems { get; set; } = null!;
    }
}
