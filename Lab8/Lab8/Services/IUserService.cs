using System.Collections.Generic;
using Lab8.Models.View;

namespace Lab8.Services
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