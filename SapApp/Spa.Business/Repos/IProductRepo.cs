using Spa.Business.Models;
using System.Collections.Generic;

namespace Spa.Business.Repos
{
    public interface IProductRepo
    {
        IEnumerable<Product> Get(string prefix);
        IEnumerable<Product> GetProductsCheaperThan(double threshold);
        Product GetById(int productId);
    }
}