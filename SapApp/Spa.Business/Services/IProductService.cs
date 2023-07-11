using Spa.Business.Models;
using System.Collections.Generic;

namespace Spa.Business.Services
{
    public interface IProductService
    {
        IEnumerable<Product> Get(string prefix);
        IEnumerable<Product> GetproductsCheaperThan(double threshold);
        Product GetById(int productId);
    }
}