using System.Collections.Generic;

namespace Handlers.Classes
{
    public static class Services<T> where T : class
    {
        public static List<T> ToList(IEnumerable<T> TEntity)
        {
            List<T> list = new List<T>();
            foreach (T t in TEntity) list.Add(t);

            return list;
        }
    }
}
