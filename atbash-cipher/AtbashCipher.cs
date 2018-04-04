using System;
using System.Collections.Generic;
using System.Linq;

public static class AtbashCipher
{
    public static string Encode(string plainValue) 
        => plainValue.Transform().BreakIntoGroups().Stringify();

    public static string Decode(string encodedValue) 
        => encodedValue.Transform().Stringify();

    private static IEnumerable<char> Transform(this IEnumerable<char> source)
    {
        foreach(char c in source)
        {
            if (char.IsDigit(c))
            {
                yield return c;
            }
            else if (char.IsLetter(c))
            {
                yield return (char)(('z' - char.ToLower(c)) + 'a');
            }
        }
    }

    private static IEnumerable<char> BreakIntoGroups(this IEnumerable<char> source)
    {
        int index = 0;
        foreach (char letter in source)
        {
            if (index > 0 && index % 5 == 0)
            {
                yield return ' ';
            }
            yield return letter;
            index++;
        }
    }

    private static string Stringify(this IEnumerable<char> source) => new string(source.ToArray());
}