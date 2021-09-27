using Handlers.Interfaces;
using Models.Classes;
using System.Collections.Generic;

namespace Handlers.Classes
{
    public sealed class MessageService : CRUD<Message>, ICRUD<Message>
    {
        private MessageService() { }
        public static bool Create(Message message) => Transaction((MessengerDb) => CreateEntity(MessengerDb, message));
        public static List<Message> Read() => Transaction((MessengerDb) => ReadEntity(MessengerDb));
        public static bool Update(int id, object newUser) => Transaction((MessengerDb) => UpdateEntity(MessengerDb, id, newUser));
        public static bool Delete(int id) => Transaction((MessengerDb) => DeleteEntity(MessengerDb, id));
    }
}