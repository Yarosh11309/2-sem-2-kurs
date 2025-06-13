namespace sem_2_k_2.Application.Interfaces
{
    using sem_2_k_2.Domain.Entities;
    public interface ITournamentRepository
    {
        Task<IEnumerable<Tournament>> GetAllAsync();
        Task AddAsync(Tournament tournament);
        Task DeleteAsync(int id);
    }
}
