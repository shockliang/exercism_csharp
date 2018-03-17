using System;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (span > digits.Length || span < 0 || digits.Any(c => c > '9' || c < '0'))
            throw new ArgumentException();

        var ints = digits.Select(c => c - '0');
        return Enumerable.Range(0, digits.Length - span + 1)
                .Select(i => ints.Skip(i).Take(span))
                .Max(s => s.Aggregate(1, (i, p) => i * p));
    }
}