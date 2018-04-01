using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        var list = new List<object>();

        foreach (var item in input)
        {
            switch (item)
            {
                case IEnumerable nest:
                    foreach (var nestItem in nest)
                    {
                        if (nestItem is IEnumerable)
                            list.AddRange(Flatten(nestItem as IEnumerable) as IEnumerable<object>);
                        else if (nestItem != null)
                            list.Add(nestItem);
                    }
                    break;

                case object obj:
                    list.Add(obj);
                    break;
            }
        }
        return list;
    }
}