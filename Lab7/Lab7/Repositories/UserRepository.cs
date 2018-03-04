using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab7.Data.Entities;
using Lab7.Data;

namespace Lab7.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(SubDbContext context)
        {
            this.context = context;
        }

        public void DeleteUser(int id)
        {
            User toRemove = context.Users.Find(id);
            context.Users.Remove(toRemove);
            context.SaveChanges();
        }

        public User GetUser(int id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }

        public void SaveUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User updateUser = context.Users.Find(user.ID);
            if (null == updateUser)
            {
                return;
            }
            updateUser.EmailAddress = user.EmailAddress;
            updateUser.FirstName = user.FirstName;
            updateUser.GPA = user.GPA;
            updateUser.LastName = user.LastName;
            updateUser.MiddleName = user.MiddleName;
            updateUser.YearsInSchool = user.YearsInSchool;
            context.SaveChanges();
        }

        private SubDbContext context;
    }
}