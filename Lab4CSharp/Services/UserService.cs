using Lab4CSharp.Models;
using Lab4CSharp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp.Services
{
    class UserService
    {
        private static FileRepository Repository = new FileRepository();

        public List<User> GetAllUsers()
        {
            var res = new List<User>();
            foreach (var user in Repository.GetAll())
            {
                res.Add(new User(user.FirstName, user.LastName, user.Email, user.Birthdate.Value));
            }
            return res;
        }
    }
}
