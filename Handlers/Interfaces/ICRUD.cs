using Models.Classes;
using System;
using System.Collections.Generic;

namespace Handlers.Interfaces
{
    public interface ICRUD<T> where T : class
    {
        public static bool Create(T entity) => throw new NotImplementedException();
        public static List<T> Read() => throw new NotImplementedException();
        public static bool Update(int id, object newEntity) => throw new NotImplementedException();
        public static bool Delete(int id) => throw new NotImplementedException();
        public static dynamic Transaction(Func<MessengerDbContext, object> func) => throw new NotImplementedException();
    }
}
