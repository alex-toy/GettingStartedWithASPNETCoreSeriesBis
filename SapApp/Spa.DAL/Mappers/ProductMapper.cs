using Spa.Business.Models;
using Spa.DAL.POCOS;
using System.Collections.Generic;
using System.Linq;

namespace Spa.DAL.Mappers
{
    public static class ProductMapper
    {
        public static Product Map(this ProductDb productDb)
        {
            Product product = new Product()
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Description = productDb.Description,
                Price = productDb.Price
            };

            return product;
        }
        public static ProductDb Map(this Product product)
        {
            ProductDb productDb = new ProductDb()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            return productDb;
        }

        public static IEnumerable<Product> Map(this IEnumerable<ProductDb> productDbs)
        {
            IEnumerable<Product> products = productDbs.Select(weatherForecastDto => weatherForecastDto.Map());

            return products;
        }

        public static IEnumerable<ProductDb> Map(this IEnumerable<Product> products)
        {
            IEnumerable<ProductDb> productDbs = products.Select(weatherForecastDto => weatherForecastDto.Map());

            return productDbs;
        }
    }
}
