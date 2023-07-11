using Spa.Business.Models;
using Spa.Business.Repos;
using System.Collections.Generic;

namespace Spa.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public IEnumerable<Product> Get(string prefix)
        {
            IEnumerable<Product> products = _productRepo.Get(prefix);
            return products;
        }

        public Product GetById(int productId)
        {
            Product product = _productRepo.GetById(productId);
            return product;
        }

        public IEnumerable<Product> GetproductsCheaperThan(double threshold)
        {
            IEnumerable<Product> products = _productRepo.GetProductsCheaperThan(threshold);
            return products;
        }
    }
}
