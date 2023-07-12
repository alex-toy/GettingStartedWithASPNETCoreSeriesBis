using Spa.Business.Models;
using Spa.DAL.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spa.DAL.Mappers
{
    public static class UserMapper
    {
        public static User Map(this UserDb userDb)
        {
            User user = new User()
            {
                Id = userDb.Id,
                Name = userDb.Name,
                Profession = userDb.Profession,
                Age = userDb.Age
            };

            return user;
        }
        public static UserDb Map(this User user)
        {
            UserDb userDb = new UserDb()
            {
                Id = user.Id,
                Name = user.Name,
                Profession = user.Profession,
                Age = user.Age
            };

            return userDb;
        }

        public static IEnumerable<User> Map(this IEnumerable<UserDb> productDbs)
        {
            IEnumerable<User> users = productDbs.Select(userDb => userDb.Map());

            return users;
        }

        public static IEnumerable<UserDb> Map(this IEnumerable<User> products)
        {
            IEnumerable<UserDb> productDbs = products.Select(user => user.Map());

            return productDbs;
        }
    }
}
