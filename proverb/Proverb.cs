using System;
using System.Linq;
using System.Collections.Generic;

public static class Proverb
{
    private static readonly IEnumerable<string> words = new string[] { "nail", "shoe", "horse", "rider", "message", "battle", "kingdom" };
    private static IList<string> proverbs => words
                                                .Zip(words.Skip(1), (result1, result2) => $"For want of a {result1} the {result2} was lost.")
                                                .Concat(new []{ "And all for the want of a horseshoe nail." })
                                                .ToList();

    public static string Line(int line)
    {
        return line > 0 && line <= proverbs.Count ? proverbs[line - 1] : "";
    }

    public static string AllLines() => string.Join("\n", proverbs);
}