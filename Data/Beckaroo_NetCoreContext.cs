using Microsoft.EntityFrameworkCore;
using Beckaroo_NetCore.Models;

namespace Beckaroo_NetCore.Data
{
    public class Beckaroo_NetCoreContext : DbContext
    {
        public Beckaroo_NetCoreContext(DbContextOptions<Beckaroo_NetCoreContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Blog> Blog { get; set; }
    }
}