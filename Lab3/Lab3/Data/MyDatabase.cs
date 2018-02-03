using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3.Data.Entities;

namespace Lab3.Data
{
    static public class MyDatabase
    {
        static MyDatabase()
        {
            database = new ActualDatabase();
            //AddUser(new User("Joe", "P", "Miller", "joseph.miller@oit.edu", 4, 3.89));
            //AddUser(new User("Joe2", "P", "Miller", "jmnintendo@gmail.com", 5, 3.90));
        }

        public static int AddUser(User newUser)
        {
            return database.AddUser(newUser);
        }

        private class ActualDatabase
        {
            public ActualDatabase()
            {
                users = new List<User>();
                idIndex = User.INVALID_USER_ID;
            }

            public int AddUser(User newUser)
            {
                if (User.INVALID_USER_ID != newUser.Id)
                {
                    throw new System.ApplicationException("User id must be empty.");
                }
                newUser.Id = ++idIndex;
                users.Add(newUser);
                return idIndex;
            }

            public User GetUser(int userID)
            {
                if (User.INVALID_USER_ID == idIndex)
                {
                    throw new System.ApplicationException("No users in database.");
                }

                if (userID > idIndex)
                {
                    throw new System.ApplicationException("User ID not found in database.");
                }

                if (null != users[userID] &&
                    userID == users[userID].Id)
                {
                    return users[userID];
                }

                foreach(User user in users)
                {
                    if (userID == user.Id)
                    {
                        return user;
                    }
                }

                throw new System.ApplicationException("User ID not found in database.");
            }

            public IReadOnlyList<User> GetUsers()
            {
                return users;
            }

            private List<User> users;
            private int        idIndex;
        }

        public static IReadOnlyList<User> GetUsers()
        {
            return database.GetUsers();
        }

        private static ActualDatabase database;
    }
}
