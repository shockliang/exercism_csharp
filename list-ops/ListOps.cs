using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        var count = 0;
        foreach (var item in input)
        {
            count++;
        }
        return count;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        var reversed = new List<T>();
        for (int i = Length(input) - 1; i >= 0; i--)
        {
            reversed.Add(input[i]);
        }
        return reversed;
    }

    public static List<TOut> Map<TIn, TOut>(Func<TIn, TOut> map, List<TIn> input)
    {
        var mapList = new List<TOut>();
        foreach (var item in input)
        {
            mapList.Add(map.Invoke(item));
        }

        return mapList;
    }

    public static List<T> Filter<T>(Func<T, bool> predicate, List<T> input)
    {
        var filtered = new List<T>();
        foreach (var item in input)
        {
            if (predicate.Invoke(item))
                filtered.Add(item);
        }
        return filtered;
    }

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
    {
        TOut result = start;
        var reversed = Reverse(input);
        foreach (var item in reversed)
        {
            result = func.Invoke(item, result);
        }

        return result;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        var result = new List<T>();

        foreach (var item in input)
        {
            result = Append(result, item);
        }

        return result;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        var result = new List<T>(left);

        foreach (var item in right)
        {
            result.Add(item);
        }

        return result;
    }
}