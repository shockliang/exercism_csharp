using System;
using System.Linq;
using System.Collections.Generic;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        return limit < 2 ? throw new ArgumentOutOfRangeException() :
                Enumerable.Range(2, limit - 1)
                .Aggregate(new List<int>(Enumerable.Range(2, limit - 1)), (primes, number) =>
                {
                    primes.RemoveAll(x => x % number == 0 && x != number);
                    return primes;
                })
                .ToArray();
    }
}