using Spa.Business.Models;
using System.Collections.Generic;

namespace Spa.Business.Services
{
    public interface IUserService
    {
        IEnumerable<User> Get(string prefix);
    }
}