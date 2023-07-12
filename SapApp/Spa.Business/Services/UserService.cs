using Spa.Business.Models;
using Spa.Business.Repos;
using System.Collections.Generic;

namespace Spa.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public IEnumerable<User> Get(string prefix)
        {
            IEnumerable<User> users = _userRepo.Get(prefix);
            return users;
        }
    }
}
