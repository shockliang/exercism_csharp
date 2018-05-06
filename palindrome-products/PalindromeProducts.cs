using System;
using System.Collections.Generic;
using System.Linq;

public class Palindrome
{
    public int Value { get; private set; }

    public ISet<Tuple<int, int>> Factors { get; private set; }

    public static Palindrome Largest(int maxFactor)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static Palindrome Largest(int minFactor, int maxFactor)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static Palindrome Smallest(int maxFactor)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static Palindrome Smallest(int minFactor, int maxFactor)
    {
        throw new NotImplementedException("You need to implement this function.");
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
}
