using System.Collections.Concurrent;

namespace sem_2_k_2.Models
{
    public class ProductService
    {
        private readonly ConcurrentDictionary<int, Product> _products = new();
        private int _nextId = 1;

        public IEnumerable<Product> GetAll() => _products.Values.OrderBy(p => p.Id);

        public void Add(Product product)
        {
            product.Id = _nextId++;
            _products[product.Id] = product;
        }

        public void Remove(int id)
        {
            _products.TryRemove(id, out _);
        }
    }
}
