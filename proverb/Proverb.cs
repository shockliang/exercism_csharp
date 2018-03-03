using System;
using System.Linq;
using System.Collections.Generic;

public static class Proverb
{
    private static readonly IEnumerable<string> words = new string[] { "nail", "shoe", "horse", "rider", "message", "battle", "kingdom" };
    private static IList<string> proverbs => GenerateProverb(words);

    private static IList<string> GenerateProverb(IEnumerable<string> words)
    {
        var _proverbs = new List<string>();
        for (int i = 0; i < words.Count() - 1; i++)
        {
            var twoWords = words.Skip(i).Take(2).ToArray();
            _proverbs.Add($"For want of a {twoWords[0]} the {twoWords[1]} was lost.");
        }
        _proverbs.Add("And all for the want of a horseshoe nail.");
        return _proverbs;
    }

    public static string Line(int line)
    {
        return line > 0 && line <= proverbs.Count ? proverbs[line - 1] : "";
    }

    public static string AllLines()
    {
        return string.Join("\n", proverbs);
    }
}