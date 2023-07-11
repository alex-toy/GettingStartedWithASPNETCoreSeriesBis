using Spa.Business.Models;
using Spa.Business.Repos;
using Spa.DAL.Mappers;
using Spa.DAL.POCOS;
using System.Collections.Generic;
using System.Linq;

namespace Spa.DAL
{
    public class ProductRepo : IProductRepo
    {
        public IEnumerable<Product> Get(string prefix)
        {
            List<ProductDb> productDbs = GetAll();

            bool hasPrefix = !string.IsNullOrEmpty(prefix);
            IEnumerable<ProductDb> selectedProducts = hasPrefix ? productDbs.Where(p => p.Name.StartsWith(prefix)) : productDbs;

            IEnumerable<Product> products = selectedProducts.Map();

            return products;
        }

        public IEnumerable<Product> GetProductsCheaperThan(double threshold)
        {
            List<ProductDb> productDbs = GetAll();

            IEnumerable<ProductDb> selectedProducts = productDbs.Where(p => p.Price <= threshold);

            IEnumerable<Product> products = selectedProducts.Map();

            return products;
        }

        public Product GetById(int productId)
        {
            List<ProductDb> productDbs = GetAll();

            ProductDb selectedProductDb = productDbs.FirstOrDefault(p => p.Id == productId);

            Product product = selectedProductDb.Map();

            return product;
        }

        private static List<ProductDb> GetAll()
        {
            return new List<ProductDb>()
            {
                new ProductDb() { Id = 1, Name = "shoes", Description = "very good", Price = 99.99},
                new ProductDb() { Id = 2, Name = "pants", Description = "very good", Price = 39.99},
                new ProductDb() { Id = 3, Name = "shirt", Description = "very good", Price = 39.99},
                new ProductDb() { Id = 4, Name = "scarf", Description = "very good", Price = 98.99}
            };
        }
    }
}
