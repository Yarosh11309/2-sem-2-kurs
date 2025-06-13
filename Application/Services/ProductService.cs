using sem_2_k_2.Application.Interfaces;
using sem_2_k_2.Domain.Entities;

namespace sem_2_k_2.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Product>> GetProductsAsync() => _repo.GetAllAsync();
        public Task AddProductAsync(Product product) => _repo.AddAsync(product);
        public Task DeleteProductAsync(int id) => _repo.DeleteAsync(id);
    }
}
