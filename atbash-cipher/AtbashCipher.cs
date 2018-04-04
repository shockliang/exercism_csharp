using System;
using System.Linq;

public static class AtbashCipher
{
    public static string Encode(string plainValue)
    {
        return string.Concat(
             plainValue
            .Where(char.IsLetterOrDigit)
            .Select(char.ToLower)
            .Select(c => char.IsLetter(c) ? (char)('a' + 'z' - c) : c)
            .SelectMany((c, index) => (index != 0) && (index % 5 == 0) ? $" {c}" : $"{c}")
            );
    }

    public static string Decode(string encodedValue)
    {
        return string.Concat(
            encodedValue
            .Where(char.IsLetterOrDigit)
            .Select(c => char.IsLetter(c) ? (char)('a' + 'z' - c) : c)
            );
    }
}