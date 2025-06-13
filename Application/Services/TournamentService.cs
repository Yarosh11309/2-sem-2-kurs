using sem_2_k_2.Application.Interfaces;
using sem_2_k_2.Domain.Entities;

namespace sem_2_k_2.Application.Services
{
    public class TournamentService
    {
        private readonly ITournamentRepository _repo;
        public TournamentService(ITournamentRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Tournament>> GetTournamentsAsync() => _repo.GetAllAsync();
        public Task AddTournamentAsync(Tournament tournament) => _repo.AddAsync(tournament);
        public Task DeleteTournamentAsync(int id) => _repo.DeleteAsync(id);
    }
}
