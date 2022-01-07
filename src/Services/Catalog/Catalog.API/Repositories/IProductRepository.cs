using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    /// <summary>
    /// Database access Interface for Product repository.
    /// </summary>
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(string id);

        Task<IEnumerable<Product>> GetProductByName(string name);

        Task<IEnumerable<Product>> GetProductByCatagory(string categoryName);

        Task CreateProduct(Product product);

        Task<bool> UpdateProduct(Product product);

        Task<bool>  DeleteProduct(string id);
    }
}
