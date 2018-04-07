using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public static class FoodChain
{
    private static string[] swallowed = new string[] { "fly", "spider", "bird", "cat", "dog", "goat", "cow", "horse" };

    private static IDictionary<string, string> perfaces = new Dictionary<string, string>()
    {
        ["fly"] = "I don't know why she swallowed the fly. Perhaps she'll die.",
        ["spider"] = "wriggled and jiggled and tickled inside her.",
        ["bird"] = "How absurd to swallow a bird!",
        ["cat"] = "Imagine that, to swallow a cat!",
        ["dog"] = "What a hog, to swallow a dog!",
        ["goat"] = "Just opened her throat and swallowed a goat!",
        ["cow"] = "I don't know how she swallowed a cow!",
        ["horse"] = "She's dead, of course!"
    };

    public static string Recite(int startVerse, int endVerse)
    {
        var allVerses = new List<string>();
        for (int i = startVerse; i <= endVerse; i++)
        {
            var verses = new List<string>();
            verses.AddRange(GetEndVerse(i));

            allVerses.Add(string.Join('\n', verses));
        }

        return string.Join("\n\n", allVerses);
    }

    private static IEnumerable<string> GetEndVerse(int endVerse)
    {
        yield return $"I know an old lady who swallowed a {swallowed[endVerse - 1]}.";
        var key = swallowed[endVerse - 1];
        yield return key.Equals("spider") ? $"It {perfaces[key]}" : perfaces[key];

        if (key.Equals("horse")) { yield break; }

        for (int i = endVerse - 1; i > 0; i--)
        {
            var next = i - 1 >= 0 ? swallowed[i - 1] : "";

            next = next.Equals("spider") ? $"{next} that {perfaces[next]}" : $"{next}.";

            yield return $"She swallowed the {swallowed[i]} to catch the {next}";

            if (i == 1)
                yield return perfaces[swallowed[0]];
        }
    }
}