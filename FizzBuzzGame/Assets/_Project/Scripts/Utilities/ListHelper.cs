using System.Collections.Generic;
using System.Linq;

namespace AlphDevCode.Utilities
{
    public static class ListHelper
    {
        public static T GetItemAfter<T>(this IList<T> list, T item)
        {
            return list.SkipWhile(t => !Equals(t, item)).Skip(1)
                .DefaultIfEmpty(list[0]).FirstOrDefault();
        }
        
        public static T GetItemBefore<T>(this IList<T> list, T item)
        {
            return list.TakeWhile(t => !Equals(t, item))
                .DefaultIfEmpty(list[^1]).LastOrDefault();
        }
    }
}