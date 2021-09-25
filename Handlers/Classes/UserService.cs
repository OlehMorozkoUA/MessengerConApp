using Models.Classes;
using System.Collections.Generic;

namespace Handlers.Classes
{
    public class UserService
    {
        public MessengerDbContext DbContext { get; set; }
        public UserService(MessengerDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void CreateUser(User user)
        {
            DbContext.Add(user);
            DbContext.SaveChanges();
        }
    }
}
