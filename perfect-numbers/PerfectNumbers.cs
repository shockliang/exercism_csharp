using System;
using System.Linq;
using System.Collections.Generic;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException();

        var result = Enumerable.Range(1, number - 1).Sum(x => number % x == 0 ? x : 0);

        if (result == number)
            return Classification.Perfect;
        else if (result > number)
            return Classification.Abundant;
        else
            return Classification.Deficient;
    }
}
