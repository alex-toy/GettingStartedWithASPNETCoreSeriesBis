using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spa.Business.Models;
using Spa.Business.Services;
using System.Collections.Generic;

namespace SapApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService weatherService)
        {
            _logger = logger;
            _productService = weatherService;
        }

        [HttpGet("products")]
        public IEnumerable<Product> Get(string prefix = "")
        {
            IEnumerable<Product> products = _productService.Get(prefix);
            return products;
        }

        [HttpGet("productsbyid")]
        public IActionResult GetById(int productId)
        {
            Product product = _productService.GetById(productId);
            return Content(product.Name);
        }

        [HttpGet("productscheaperthan")]
        public IEnumerable<Product> GetproductsCheaperThan(double threshold)
        {
            IEnumerable<Product> products = _productService.GetproductsCheaperThan(threshold);
            return products;
        }
    }
}
