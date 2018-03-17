using System.Collections.Generic;
using Lab9.Models.View;

namespace Lab9.Services
{
    public interface IUserService
    {
        UserViewModel GetUser(int ID);

        IEnumerable<UserViewModel> GetAllUsers();

        void SaveUser(UserViewModel user);

        void UpdateUser(UserViewModel user);

        void DeleteUser(int ID);
    }
}