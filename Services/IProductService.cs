using sem_2_k_2.Models;

namespace sem_2_k_2.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Delete(int id);
    }
}
