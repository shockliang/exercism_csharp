using System;
using System.Linq;
using System.Collections.Generic;

public class Series
{
    private readonly string numbers;

    public Series(string numbers)
    {
        this.numbers = numbers;
    }

    public int[][] Slices(int sliceLength)
    {
        return sliceLength > numbers.Length
            ? throw new ArgumentException()
            : Enumerable.Range(0, numbers.Length - sliceLength + 1)
                .Select(i => numbers.Skip(i).Take(sliceLength)
                .Select(c => (int)char.GetNumericValue(c)).ToArray()).ToArray();
    }
}