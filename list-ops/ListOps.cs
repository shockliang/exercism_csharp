using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input)
        => Foldl((count, item) => count + 1, 0, input);

    public static List<T> Reverse<T>(List<T> input)
        => Foldl((list, item) => Append(new List<T> { item }, list), new List<T>(), input);

    public static List<TOut> Map<TIn, TOut>(Func<TIn, TOut> map, List<TIn> input)
        => Foldl((list, item) => Append(list, new List<TOut>() { map.Invoke(item) }), new List<TOut>(), input);

    public static List<T> Filter<T>(Func<T, bool> predicate, List<T> input)
        => Foldl((list, item) => predicate.Invoke(item) ? Append(list, new List<T>() { item }) : list, new List<T>(), input);

    public static TOut Foldl<TIn, TOut>(Func<TOut, TIn, TOut> func, TOut start, List<TIn> input)
    {
        TOut result = start;

        foreach (var item in input)
        {
            result = func.Invoke(result, item);
        }

        return result;
    }

    public static TOut Foldr<TIn, TOut>(Func<TIn, TOut, TOut> func, TOut start, List<TIn> input)
        => Foldl((list, item) => func.Invoke(item, list), start, Reverse(input));

    public static List<T> Concat<T>(List<List<T>> input)
        => Foldl((list, item) => Append(list, item), new List<T>(), input);

    public static List<T> Append<T>(List<T> left, List<T> right)
        => Foldl((list, item) => { list.Add(item); return list; }, new List<T>(left), right);
}