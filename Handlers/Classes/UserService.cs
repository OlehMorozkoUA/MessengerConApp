using Models.Classes;
using System.Collections.Generic;

namespace Handlers.Classes
{
    public static class UserService
    {
        public static MessengerDbContext DbContext { get; set; } = new MessengerDbContext();
        public static void CreateUser(User user)
        {
            DbContext.Add(user);
            DbContext.SaveChanges();
        }
    }
}
