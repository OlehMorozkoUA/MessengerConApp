using Handlers.Classes;
using Models.Classes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Handlers.Interfaces
{
    public class UserCRUD
    {
        protected static bool CreateUser(MessengerDbContext MessengerDb, User user)
        {
            try
            {
                MessengerDb.Add(user);
                MessengerDb.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        protected static List<User> ReadUser(MessengerDbContext MessengerDb)
        {
            List<User> users = new List<User>();
            try
            {
                users = Services<User>.ToList(MessengerDb.Users);
            }
            catch (Exception ex) { }

            return users;
        }

        protected static bool UpdateUser(MessengerDbContext MessengerDb, int id, object newUser)
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
        protected static bool DeleteUser(MessengerDbContext MessengerDb, int id)
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
    }
}
