using System;
using System.Linq;
using System.Collections.Generic;

public class Series
{
    private readonly IEnumerable<int> numbers;

    public Series(string numbers)
    {
        this.numbers = numbers.Select(c => (int)char.GetNumericValue(c));
    }

    public int[][] Slices(int sliceLength)
    {
        return sliceLength > numbers.Count()
            ? throw new ArgumentException()
            : Enumerable.Range(0, numbers.Count() - sliceLength + 1)
                .Select(i => numbers.Skip(i).Take(sliceLength).ToArray()).ToArray();
    }
}