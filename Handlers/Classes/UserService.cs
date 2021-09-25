using Models.Classes;
using System.Collections.Generic;

namespace Handlers.Classes
{
    public static class UserService
    {
        public static void CreateUser(User user)
        {
            using (MessengerDbContext MessengerDb = new MessengerDbContext())
            {
                MessengerDb.Add(user);
                MessengerDb.SaveChanges();
            }
        }
    }
}
