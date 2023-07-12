using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spa.Business.Models;
using Spa.Business.Services;
using System.Collections.Generic;

namespace ActionReturnTypeApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("users")]
        public IEnumerable<User> Get(string prefix = "")
        {
            IEnumerable<User> users = _userService.Get(prefix);
            return users;
        }
    }
}
