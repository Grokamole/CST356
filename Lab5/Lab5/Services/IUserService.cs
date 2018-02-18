using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models.View;

namespace Lab5.Services
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