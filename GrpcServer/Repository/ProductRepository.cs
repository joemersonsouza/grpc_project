using Core;
using Core.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Product[] products = { new Product("A", "Product A", 247.90), new Product("B", "Product B", 345.99)};
        public Task<List<Product>> GetAllAsync()
        {
            return Task.FromResult(products.ToList());
        }
    }
}
