using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    /// <summary>
    /// Database catalog context interface.
    /// Contains db connection context to specific collection in database.
    /// </summary>
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
