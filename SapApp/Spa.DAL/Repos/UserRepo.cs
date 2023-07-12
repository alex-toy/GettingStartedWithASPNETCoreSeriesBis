using Spa.Business.Models;
using Spa.DAL.Mappers;
using Spa.DAL.POCOS;
using System.Collections.Generic;
using System.Linq;

namespace Spa.DAL.Repos
{
    public class UserRepo
    {
        public IEnumerable<User> Get(string prefix)
        {
            List<UserDb> userDbs = GetAll();

            bool hasPrefix = !string.IsNullOrEmpty(prefix);
            IEnumerable<UserDb> selectedUserDbs = hasPrefix ? userDbs.Where(p => p.Name.StartsWith(prefix)) : userDbs;

            IEnumerable<User> products = selectedUserDbs.Map();

            return products;
        }

        private static List<UserDb> GetAll()
        {
            return new List<UserDb>()
            {
                new UserDb() { Id = 1, Name = "alex", Profession = "dev", Age = 39},
                new UserDb() { Id = 2, Name = "seb", Profession = "drawer", Age = 34},
                new UserDb() { Id = 3, Name = "kate", Profession = "woman at home", Age = 53},
                new UserDb() { Id = 4, Name = "matt", Profession = "engineer", Age = 13}
            };
        }
    }
}
