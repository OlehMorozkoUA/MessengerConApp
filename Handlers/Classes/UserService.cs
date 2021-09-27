using Handlers.Interfaces;
using Models.Classes;
using System;
using System.Collections.Generic;

namespace Handlers.Classes
{
    public sealed class UserService : CRUD<User>, ICRUD<User>
    {
        private UserService() { }
        public static bool Create(User user) => Transaction((MessengerDb) => CreateEntity(MessengerDb, user));
        public static List<User> Read() => Transaction((MessengerDb) => ReadEntity(MessengerDb));
        public static bool Update(int id, object newUser) => Transaction((MessengerDb) => UpdateEntity(MessengerDb, id, newUser));
        public static bool Delete(int id) => Transaction((MessengerDb) => DeleteEntity(MessengerDb, id));
        public static dynamic Transaction(Func<MessengerDbContext, object> func)
        {
            using (MessengerDbContext MessengerDb = new MessengerDbContext())
                return func(MessengerDb);
        }
    }
}
