using System;
using System.Collections.Generic;
using System.Linq;

public static class WordCount
{
    private static char[] Separators = " ,\n\":.!@$%^&".ToCharArray();

    public static IDictionary<string, int> Countwords(string phrase) =>
        phrase
            .Split(Separators, StringSplitOptions.RemoveEmptyEntries)
            .GroupBy(w => w.Trim('\'').ToLowerInvariant())
            .ToDictionary(group => group.Key, group => group.Count());
}