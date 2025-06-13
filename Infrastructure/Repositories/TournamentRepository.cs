using Microsoft.EntityFrameworkCore;
using sem_2_k_2.Application.Interfaces;
using sem_2_k_2.Domain.Entities;
using sem_2_k_2.Infrastructure.Data;

namespace sem_2_k_2.Infrastructure.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly AppDbContext _db;
        public TournamentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync()
        {
            return await _db.Tournaments.ToListAsync();
        }

        public async Task AddAsync(Tournament tournament)
        {
            _db.Tournaments.Add(tournament);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Tournaments.FindAsync(id);
            if (entity != null)
            {
                _db.Tournaments.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}
