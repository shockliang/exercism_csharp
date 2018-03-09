using System;
using System.Linq;
using System.Collections.Generic;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if(limit < 2) throw new ArgumentOutOfRangeException();
        
        var primes = new HashSet<int>(Enumerable.Range(2, limit - 1));
        for (var i = 2; i <= Math.Sqrt(limit); i++)
        {
            if (primes.Contains(i))
            {
                for (var j = i * i; j <= limit; j += i)
                {
                    primes.Remove(j);
                }
            }
        }
        return primes.ToArray();
    }
}