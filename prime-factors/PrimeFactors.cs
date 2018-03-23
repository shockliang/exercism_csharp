using System;
using System.Linq;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static int[] Factors(long number) => GetFactors(number, 2).ToArray();

    private static IEnumerable<int> GetFactors(long number, long step)
    {
        while (number != 1)
        {
            if (number % step == 0)
            {
                number /= step;
                yield return Convert.ToInt32(step);
            }
            else
            {
                step++;
            }
        }
    }
}