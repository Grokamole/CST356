using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab7.Models.View;
using Lab7.Repositories;
using Lab7.Data.Entities;

namespace Lab7.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }
        public void DeleteUser(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            List<UserViewModel> model = new List<UserViewModel>();

            foreach(User user in repository.GetUsers())
            {
                model.Add(MapToUserViewModel(user));
            }

            return model;
        }

        public UserViewModel GetUser(int ID)
        {
            return MapToUserViewModel(repository.GetUser(ID));
        }

        public void SaveUser(UserViewModel user)
        {
            repository.SaveUser(MapToUser(user));
        }

        public void UpdateUser(UserViewModel user)
        {
            repository.UpdateUser(MapToUser(user));
        }

        private User MapToUser(UserViewModel inputUser)
        {
            User outputUser = new User();

            outputUser.EmailAddress = inputUser.EmailAddress;
            outputUser.FirstName = inputUser.FirstName;
            outputUser.GPA = inputUser.GPA;
            outputUser.ID = inputUser.ID;
            outputUser.LastName = inputUser.LastName;
            outputUser.MiddleName = inputUser.MiddleName;
            outputUser.YearsInSchool = inputUser.YearsInSchool;

            return outputUser;
        }

        private UserViewModel MapToUserViewModel(User inputUser)
        {
            UserViewModel outputUser = new UserViewModel();

            outputUser.EmailAddress = inputUser.EmailAddress;
            outputUser.FirstName = inputUser.FirstName;
            outputUser.GPA = inputUser.GPA;
            outputUser.ID = inputUser.ID;
            outputUser.LastName = inputUser.LastName;
            outputUser.MiddleName = inputUser.MiddleName;
            outputUser.YearsInSchool = inputUser.YearsInSchool;

            return outputUser;
        }
    }
}