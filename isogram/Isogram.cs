using System;
using System.Collections.Generic;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        return word
                .Where(char.IsLetter)
                .GroupBy(char.ToLower)
                .All(g => g.Count() < 2);
    }
}
