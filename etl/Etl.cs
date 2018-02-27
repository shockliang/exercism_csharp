using System;
using System.Linq;
using System.Collections.Generic;

public static class Etl
{
    public static IDictionary<string, int> Transform(IDictionary<int, IList<string>> old)
    {
        return old.SelectMany(pair => pair.Value.Select(k => new { key = k.ToLower(), value = pair.Key }))
          .ToDictionary(x => x.key, y => y.value);
    }
}