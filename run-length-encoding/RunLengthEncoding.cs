using System;
using System.Text.RegularExpressions;
using System.Linq;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        var pattern = @"(\D)(\1+)";

        return Regex.Replace(input, pattern,
               m => (m.Groups[2].Value.Length + 1).ToString() + m.Groups[2].Value[0].ToString());
    }

    public static string Decode(string input)
    {
        var pattern = @"(\d+)(\D)";

        return Regex.Replace(input, pattern,
                 m => new string(m.Groups[2].Value[0], int.Parse(m.Groups[1].Value)));
    }
}