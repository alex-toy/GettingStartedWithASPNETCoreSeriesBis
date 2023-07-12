using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spa.Business.Models;
using Spa.Business.Services;
using System.Collections.Generic;
using System.Text.Json;

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
        public IEnumerable<Product> GetProductsCheaperThan(double threshold)
        {
            IEnumerable<Product> products = _productService.GetproductsCheaperThan(threshold);
            return products;
        }

        [HttpGet("productsjson")]
        public IActionResult GetJson(string prefix = "")
        {
            IEnumerable<Product> products = _productService.Get(prefix);

            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            return new JsonResult(products, options);
        }

        [HttpGet("ok/{format?}")]
        [FormatFilter]
        public IActionResult GetOk(string prefix = "")
        {
            IEnumerable<Product> products = _productService.Get(prefix);
            return Ok(products);
        }

        [HttpGet("xmlonly")]
        [FormatFilter]
        [Produces("application/xml")]
        public IActionResult GetXmlOnly(string prefix = "")
        {
            IEnumerable<Product> products = _productService.Get(prefix);
            return Ok(products);
        }
    }
}
