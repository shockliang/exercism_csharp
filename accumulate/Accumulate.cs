using System;
using System.Linq;
using System.Collections.Generic;

public static class AccumulateExtensions
{
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {
        var iterator = collection.GetEnumerator();

        while(iterator.MoveNext())
        {
            yield return func(iterator.Current);
        }
    }
}