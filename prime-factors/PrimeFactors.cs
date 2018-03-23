using System;
using System.Collections.Generic;
using System.Linq;

public static class PrimeFactors
{
    public static int[] Factors(long number) => EnumerateFactors(number).ToArray();

    private static IEnumerable<int> EnumerateFactors(long number)
    {
        for (var factor = 2; number != 1; factor += factor == 2 ? 1 : 2)
            for (; number % factor == 0; number /= factor)
                yield return factor;
    }
}