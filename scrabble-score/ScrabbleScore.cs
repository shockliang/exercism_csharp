using System;
using System.Linq;
using System.Collections.Generic;

public static class ScrabbleScore
{
    private static readonly IDictionary<string, int> scoreTable = new Dictionary<string, int>()
    {
        ["AEIOULNRST"] = 1,
        ["DG"] = 2,
        ["BCMP"] = 3,
        ["FHVWY"] = 4,
        ["K"] = 5,
        ["JX"] = 8,
        ["QZ"] = 10
    };

    public static int Score(string input)
    {
        return input
                .ToUpper()
                .Select(letter => scoreTable.Where(x => x.Key.Contains(letter)).Select(x => x.Value).FirstOrDefault())
                .Sum();
    }


}