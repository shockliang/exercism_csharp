using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> Countwords(string phrase)
    {
        var words = Regex.Matches(phrase, @"\w+\'*\w+|\w+")
            .Select(m => m.Value.ToLower());
        return words.Distinct().ToDictionary(x => x, y => words.Count(p => p == y));

    }
}