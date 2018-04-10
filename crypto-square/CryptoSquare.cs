using System;
using System.Linq;
using System.Collections.Generic;
using static System.String;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(this string plaintext)
    {
        return Concat(plaintext.ToLower().Where(char.IsLetterOrDigit));
    }

    public static IEnumerable<string> PlaintextSegments(this string plaintext)
    {
        var col = (int)Math.Ceiling(Math.Sqrt(plaintext.Length));

        var list = new List<string>();
        for (int i = 0; i < plaintext.Length; i += col)
        {
            list.Add(Concat(plaintext.Skip(i).Take(col)));
        }

        return list;
    }

    public static string Encoded(this string plaintext)
    {
        var segments = plaintext.Split(" ");
        var col = segments.First().Count();
        var list = new List<string>();

        for (int i = 0; i < segments.Length; i++)
        {
            if (segments[i].Length < col)
                segments[i] = segments[i].PadRight(col);
        }

        for (int i = 0; i < col; i++)
        {
            list.Add(Concat(segments.Select(s => s.ElementAt(i))));
        }

        return Join(" ", list);
    }

    public static string Ciphertext(string plaintext)
    {
        return Join(" ", plaintext
            .NormalizedPlaintext()
            .PlaintextSegments())
            .Encoded();
    }
}