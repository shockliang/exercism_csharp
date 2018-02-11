using System;
using System.Linq;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        var allResult = new List<int>();

        foreach (var item in multiples)
        {
            if (item > max)
                continue;

            var multipleResult = 0;

            var count = 1;
            while (multipleResult < max)
            {
                multipleResult = item * count;
                count++;
                if (multipleResult < max)
                    allResult.Add(multipleResult);
            }
        }

        return allResult.Distinct().Sum();
    }
}