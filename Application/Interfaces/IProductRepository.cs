namespace sem_2_k_2.Application.Interfaces
{
    using sem_2_k_2.Domain.Entities;
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task DeleteAsync(int id);
    }
}
