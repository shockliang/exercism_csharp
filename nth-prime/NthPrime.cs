using System;
using System.Collections.Generic;
using System.Linq;

public static class NthPrime
{
    public static int Prime(int nth)
    {
        if (nth <= 0) throw new ArgumentOutOfRangeException();

        var primes = GetPrimes();
        var enumerator = primes.GetEnumerator();

        for (int i = 0; i < nth; i++)
        {
            enumerator.MoveNext();
        }

        return enumerator.Current;
    }

    private static IEnumerable<int> GetPrimes()
    {
        var num = 2;
        while (true)
        {
            if (IsPrime(num))
                yield return num;

            num++;
        }
    }

    private static bool IsPrime(int number)
    {
        if (number == 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}