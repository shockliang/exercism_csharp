using System;
using System.Linq;
using System.Collections.Generic;
using static System.String;

public static class PigLatin
{
    public static string Translate(string word)
        => Join(" ", word.Split(" ").Select(w => Parse(w)));

    private static string Parse(string word)
    {
        if ("aeiou".Contains(word.ToLower().FirstOrDefault()) ||
            "yt".Equals(Concat(word.Take(2))) ||
            "xr".Equals(Concat(word.Take(2))))
        {
            return $"{word}ay";
        }
        else
        {
            var consonantClusters = new string[] {
                "ch", "sh", "sm", "sch", "str", "thr",
                "st", "gl", "qu", "squ", "th", "yt", "rh" };
            var multiCons = consonantClusters.FirstOrDefault(con => con.Equals(Concat(word.Take(con.Length))));
            if (multiCons != null)
                return $"{Concat(word.Skip(multiCons.Length).Take(word.Length - multiCons.Length))}{multiCons}ay";
            else
                return $"{Concat(word.Skip(1).Take(word.Length - 1))}{word.FirstOrDefault()}ay";
        }
    }
}