using System.Collections.Generic;
using Lab9.Data.Entities;

namespace Lab9.Repositories
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