using System;
using System.Linq;
using System.Collections.Generic;

public enum Classification
{
    Perfect = 0,
    Abundant = 1,
    Deficient = -1
}

public static class PerfectNumbers
{
    public static Classification Classify(int number) =>
        (Classification)Enumerable.Range(1, number - 1).Sum(x => number % x == 0 ? x : 0).CompareTo(number);
}
