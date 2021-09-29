using Handlers.Interfaces;
using Models.Classes;
using System.Collections.Generic;

namespace Handlers.Classes
{
    public sealed class MessageService : CRUD<Message>
    {
        private MessageService() { }
    }
}