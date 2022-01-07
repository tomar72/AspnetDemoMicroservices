using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Catalog.API.Data
{
    internal class CatalogContextSeed
    {
        /// <summary>
        /// Default seeding of Mongo database collection, if it is empty.
        /// </summary>
        /// <param name="productCollection"></param>
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "IPhone X",
                    Summary = "This phone is the biggest flagship phone",
                    Description = "This is a dummy description",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                }
            };
        }
    }
}