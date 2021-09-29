using Handlers.Classes;
using Models.Classes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Handlers.Interfaces
{
    public class CRUD<T> : ICRUD<T> where T: class
    {
        protected static bool CreateEntity(MessengerDbContext MessengerDb, T entity)
        {
            try
            {
                MessengerDb.Add(entity);
                MessengerDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        protected static List<T> ReadEntity(MessengerDbContext MessengerDb)
        {
            List<T> entities = new List<T>();
            try
            {
                IEnumerable<T> MessengerDbEntities = GetMessengerDbEntities(MessengerDb, typeof(T).Name.ToLower());
                entities = Services<T>.ToList(MessengerDbEntities);
            }
            catch (Exception) { }

            return entities;
        }
        protected static bool UpdateEntity(MessengerDbContext MessengerDb, int id, object newUser)
        {
            try
            {
                T entity = MessengerDb.Find(typeof(T), id) as T;

                PropertyInfo[] properties = entity.GetType().GetProperties();
                PropertyInfo[] newProperties = newUser.GetType().GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    for (int j = 0; j < newProperties.Length; j++)
                    {
                        if (properties[i].Name == newProperties[j].Name)
                        {
                            properties[i].SetValue(entity, newProperties[j].GetValue(newUser));
                        }
                    }
                }

                MessengerDb.Update(entity);
                MessengerDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        protected static bool DeleteEntity(MessengerDbContext MessengerDb, int id)
        {
            try
            {
                T entity = MessengerDb.Find(typeof(T), id) as T;
                MessengerDb.Remove(entity);
                MessengerDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static IEnumerable<T> GetMessengerDbEntities(MessengerDbContext MessengerDb, string type)
            => (type) switch
            {
                "attachment" => MessengerDb.Attachments as IEnumerable<T>,
                "group" => MessengerDb.Groups as IEnumerable<T>,
                "message" => MessengerDb.Messages as IEnumerable<T>,
                "user" => MessengerDb.Users as IEnumerable<T>,
                _ => null
            };
        public static dynamic Transaction(Func<MessengerDbContext, object> func)
        {
            using (MessengerDbContext MessengerDb = new MessengerDbContext())
                return func(MessengerDb);
        }

        public static bool Create(T entity) => Transaction((MessengerDb) => CreateEntity(MessengerDb, entity));
        public static List<T> Read() => Transaction((MessengerDb) => ReadEntity(MessengerDb));
        public static bool Update(int id, object newEntity) => Transaction((MessengerDb) => UpdateEntity(MessengerDb, id, newEntity));
        public static bool Delete(int id) => Transaction((MessengerDb) => DeleteEntity(MessengerDb, id));
    }
}