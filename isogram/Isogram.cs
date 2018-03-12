using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Isogram
{
    private static readonly Regex findDup = new Regex(@"(.).*\1");
    public static bool IsIsogram(string word)
    {
        return !findDup.IsMatch(new string(word.ToLower()
                                               .Where(c => Char.IsLetter(c))
                                               .ToArray()));
    }
}
