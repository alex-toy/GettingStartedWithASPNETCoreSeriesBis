using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spa.Business.Services;
using System.Collections.Generic;

namespace ActionReturnTypeApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IProductService _productService;

        public UserController(ILogger<UserController> logger, IProductService weatherService)
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
    }
}
