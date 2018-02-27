using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

public static class Pangram
{
    static readonly ImmutableHashSet<char> alphabet =
      ImmutableHashSet<char>.Empty.Union("abcdefghijklmnopqrstuvwxyz");

    public static bool IsPangram(string input)
    {
        return alphabet.Intersect(input.ToLower()).Count == alphabet.Count;
    }
}
