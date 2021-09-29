using Handlers.Interfaces;
using Models.Classes;
using System;
using System.Collections.Generic;

namespace Handlers.Classes
{
    public sealed class UserService : CRUD<User>
    {
        private UserService() { }
    }
}
