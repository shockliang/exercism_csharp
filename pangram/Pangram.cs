using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        return input.Aggregate(new HashSet<char>(), (s, c) =>
        {
            char lc = char.ToLower(c);
            if (lc >= 'a' && lc <= 'z') s.Add(lc);
            return s;
        }).Count == 26;
    }
}
