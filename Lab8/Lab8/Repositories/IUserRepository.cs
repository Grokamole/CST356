using System.Collections.Generic;
using Lab8.Data.Entities;

namespace Lab8.Repositories
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