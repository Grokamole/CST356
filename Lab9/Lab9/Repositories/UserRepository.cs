using System.Collections.Generic;
using Lab9.Data.Entities;
using Lab9.Models;

namespace Lab9.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(SubDbContext context)
        {
            this.context = context;
        }

        public void DeleteUser(int id)
        {
            User toRemove = context.Userset.Find(id);
            context.Userset.Remove(toRemove);
            context.SaveChanges();
        }

        public User GetUser(int id)
        {
            return context.Userset.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Userset;
        }

        public void SaveUser(User user)
        {
            context.Userset.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User updateUser = context.Userset.Find(user.ID);
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