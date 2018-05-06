using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Palindrome
{
    public Palindrome(int value, int minFactor, int maxFactor)
    {
        Value = value;
        Factors = Factor(value, minFactor, maxFactor);
    }
    public int Value { get; private set; }

    public ISet<Tuple<int, int>> Factors { get; private set; }

    public static Palindrome Largest(int maxFactor)
        => Largest(1, maxFactor);

    public static Palindrome Largest(int minFactor, int maxFactor)
        => new Palindrome(GetPalindromicNumbers(minFactor, maxFactor).Max(), minFactor, maxFactor);

    public static Palindrome Smallest(int maxFactor)
        => Smallest(1, maxFactor);

    public static Palindrome Smallest(int minFactor, int maxFactor)
        => new Palindrome(GetPalindromicNumbers(minFactor, maxFactor).Min(), minFactor, maxFactor);

    private static IEnumerable<int> GetPalindromicNumbers(int min, int max)
    {
        return Enumerable
            .Range(min, max - min + 1)
            .AsParallel()
            .SelectMany(i => Enumerable
                .Range(min, max - min + 1)
                .Select(j => i * j))
            .Where(num => IsPalindromicNumber(num));
    }

    public static bool IsPalindromicNumber(int num)
    {
        var temp = num;
        int a, s = 0;
        while (num > 0)
        {
            a = num % 10;
            s = s * 10 + a;
            num = num / 10;
        }

        return temp == s;
    }

    public static HashSet<Tuple<int, int>> Factor(int number, int minFactor, int maxFactor)
    {
        var factors = new HashSet<Tuple<int, int>>();
        var max = (int)Math.Sqrt(number);
        for (int factor = minFactor; factor <= max; ++factor)
        {
            if (number % factor == 0)
            {
                if (number / factor <= maxFactor)
                    factors.Add(Tuple.Create(factor, number / factor));
            }
        }
        return factors;
    }
}