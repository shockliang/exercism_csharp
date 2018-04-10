using System;
using System.Linq;
using System.Collections.Generic;
using static System.String;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(this string plaintext)
    {
        return Concat(plaintext
            .ToLower()
            .Where(char.IsLetterOrDigit));
    }

    public static IEnumerable<string> PlaintextSegments(this string plaintext)
    {
        var col = (int)Math.Ceiling(Math.Sqrt(plaintext.Length));

        return Enumerable.Range(0, plaintext.Length)
            .Where(i => i % col == 0)
            .Select(i => Concat(plaintext.Skip(i).Take(col)));
    }

    public static string Encoded(this string plaintext)
    {
        var segments = plaintext.Split(" ");
        var col = segments.First().Count();

        var paddingSegments = Enumerable.Range(0, segments.Length)
            .Select(i => segments[i].PadRight(col));

        return Join(" ", Enumerable.Range(0, col)
            .Select(i => Concat(paddingSegments.Select(s => s.ElementAt(i)))));
    }

    public static string Ciphertext(string plaintext)
    {
        return Join(" ", plaintext
            .NormalizedPlaintext()
            .PlaintextSegments())
            .Encoded();
    }
}