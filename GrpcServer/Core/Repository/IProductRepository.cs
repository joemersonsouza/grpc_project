using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
    }
}
