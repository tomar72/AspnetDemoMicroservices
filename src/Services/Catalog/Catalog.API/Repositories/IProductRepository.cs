using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(string id);

        Task<IEnumerable<Product>> GetProductByName(string name);

        Task<IEnumerable<Product>> GetProductByCatagory(string categoryName);

        Task CreateProdut(Product product);

        Task<bool> UpdateProdut(Product product);

        Task<bool>  DeleteProduct(string id);
    }
}
