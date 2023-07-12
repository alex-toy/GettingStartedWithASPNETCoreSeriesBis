using Spa.Business.Models;
using System.Collections.Generic;

namespace Spa.Business.Repos
{
    public interface IUserRepo
    {
        IEnumerable<User> Get(string prefix);
    }
}
