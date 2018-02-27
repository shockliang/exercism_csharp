using System;
using System.Linq;
using System.Collections.Generic;

public static class Etl
{
    public static IDictionary<string, int> Transform(IDictionary<int, IList<string>> old)
    {
        return old.Aggregate(new Dictionary<string, int>(), (result, dic) =>
        {
            foreach (var item in dic.Value)
            {
                result.Add(item.ToLower(), dic.Key);
            }
            return result;
        });
    }
}