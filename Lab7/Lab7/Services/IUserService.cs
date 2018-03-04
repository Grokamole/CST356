using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab7.Models.View;

namespace Lab7.Services
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