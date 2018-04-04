using System;
using System.Linq;
using System.Collections.Generic;
using static System.String;

public static class AtbashCipher
{
    private static IDictionary<char, char> mapping;

    static AtbashCipher()
    {
        mapping = new Dictionary<char, char>();
        var az = Enumerable.Range('a', 26).ToArray();
        for (int i = 0; i < az.Count(); i++)
        {
            mapping.Add((char)az[i], (char)az[az.Count() - i - 1]);
        }
    }

    public static string Encode(string plainValue)
    {
        var filtered = plainValue
            .ToLower()
            .Where(char.IsLetterOrDigit)
            .Select(c => mapping.ContainsKey(c) ? mapping[c] : c)
            .ToList();

        var fiveLetters = new List<string>();
        for (int i = 0; i < filtered.Count(); i += 5)
        {
            fiveLetters.Add(Concat(filtered.Skip(i).Take(5)));
        }
        return Join(' ', fiveLetters);
    }

    public static string Decode(string encodedValue)
    {
        var result = new List<char>();
        var filtered = encodedValue.Where(char.IsLetterOrDigit);

        foreach (var letter in filtered)
        {
            result.Add(char.IsLetter(letter) 
                ? mapping.FirstOrDefault(x => x.Value.Equals(letter)).Key 
                : letter);
        }
        return Concat(result);
    }
}
