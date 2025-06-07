using sem_2_k_2.Models;

namespace sem_2_k_2.Services
{
    public class InMemoryProductService : IProductService
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        public IEnumerable<Product> GetAll() => _products;

        public void Add(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
