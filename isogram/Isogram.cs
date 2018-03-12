using System;
using System.Collections.Generic;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        word = word.ToLower();
        return word
                .Where(x => !x.Equals(' ') && !x.Equals('-'))
                .Where(c => word.Count(x => x == c) > 1)
                .Count() == 0;
    }
}
