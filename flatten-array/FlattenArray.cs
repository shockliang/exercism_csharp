using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach (var item in input)
        {
            if (item == null) continue;
            if (item is IEnumerable nest)
                foreach (var nestItem in Flatten(nest))
                    yield return nestItem;
            else
                yield return item;
        }
    }
}