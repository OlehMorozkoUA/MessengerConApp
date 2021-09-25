using Models.Classes;

namespace Handlers.Classes
{
    public static class MessageService
    {
        public static MessengerDbContext DbContext { get; set; } = new MessengerDbContext();
    }
}
