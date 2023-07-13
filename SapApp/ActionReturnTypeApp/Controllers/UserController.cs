using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spa.Business.Models;
using Spa.Business.Services;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("usersaction")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status200OK, Type =typeof(IEnumerable<User>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<User>> GetAction(string prefix = "")
        {
            if (string.IsNullOrEmpty(prefix)) return BadRequest("prefix should not be null");

            IEnumerable<User> users = _userService.Get(prefix);

            if (!users.Any()) return NotFound("no users have been found");

            return users.ToList();
        }
    }
}
