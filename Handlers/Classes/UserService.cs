using Handlers.Interfaces;
using Models.Classes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Handlers.Classes
{
    public class UserService : ICRUD<User>
    {
        private UserService() { }
        private static bool CreateUser(MessengerDbContext MessengerDb, User user)
        {
            try
            {
                MessengerDb.Add(user);
                MessengerDb.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        private static List<User> ReadUser(MessengerDbContext MessengerDb)
        {
            List<User> users = new List<User>();
            try
            {
                users = Services<User>.ToList(MessengerDb.Users);
            }
            catch(Exception ex) { }

            return users;
        }

        private static bool UpdateUser(MessengerDbContext MessengerDb, int id, object newUser)
        {
            try
            {
                User user = MessengerDb.Find(typeof(User), id) as User;

                PropertyInfo[] properties = user.GetType().GetProperties();
                PropertyInfo[] newProperties = newUser.GetType().GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    for (int j = 0; j < newProperties.Length; j++)
                    {
                        if (properties[i].Name == newProperties[j].Name)
                        {
                            properties[i].SetValue(user, newProperties[j].GetValue(newUser));
                        }
                    }
                }

                MessengerDb.Update(user);
                MessengerDb.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private static bool DeleteUser(MessengerDbContext MessengerDb, int id)
        {
            try
            {
                User user = MessengerDb.Find(typeof(User), id) as User;
                MessengerDb.Remove(user);
                MessengerDb.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Create(User user) => Transaction((MessengerDb) => CreateUser(MessengerDb, user));
        public static List<User> Read() => Transaction((MessengerDb) => ReadUser(MessengerDb));
        public static bool Update(int id, object newUser) => Transaction((MessengerDb) => UpdateUser(MessengerDb, id, newUser));
        public static bool Delete(int id) => Transaction((MessengerDb) => DeleteUser(MessengerDb, id));
        public static dynamic Transaction(Func<MessengerDbContext, object> func)
        {
            using (MessengerDbContext MessengerDb = new MessengerDbContext())
                return func(MessengerDb);
        }
    }
}
