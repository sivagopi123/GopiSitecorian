using System;
using System.Collections.Generic;

namespace Query
{
    public static class Mylinq
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var result = new List<T>();

            foreach(var item in source)
            {
                if(predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
