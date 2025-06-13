using Microsoft.EntityFrameworkCore;

using sem_2_k_2.Domain.Entities;

namespace sem_2_k_2.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();
    }
}
