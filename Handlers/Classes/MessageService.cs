using Models.Classes;

namespace Handlers.Classes
{
    public class MessageService
    {
        public MessengerDbContext DbContext { get; set; }
        public MessageService(MessengerDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
