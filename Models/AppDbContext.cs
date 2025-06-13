using Microsoft.EntityFrameworkCore;

namespace sem_2_k_2.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items => Set<Item>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
