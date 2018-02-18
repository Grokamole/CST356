using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Data.Entities;

namespace Lab5.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetUsers();
        void SaveUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}