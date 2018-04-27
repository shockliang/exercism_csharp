using System;
using System.Linq;
using System.Collections.Generic;

public static class Transpose
{
    public static string String(string input)
    {
        if (string.IsNullOrEmpty(input))
            return "";
        var lines = input.Split('\n');
        var maxRow = lines.Max(x => x.Length);
        var maxCol = lines.Count();
        var transposed = new List<List<char>>();

        for (int i = 0; i < maxRow; i++)
        {
            transposed.Add(new List<char>(Enumerable.Repeat(' ', maxCol)));
        }

        for (int i = 0; i < lines.Count(); i++)
        {
            for (int j = 0; j < lines[i].Count(); j++)
            {
                transposed[j][i] = lines[i][j];
            }
        }
        var result = transposed.Select(x => string.Concat(x)).ToArray();
        var lastOne = result.Length - 1 > 0 ? result.Length - 1 : 0;
        result[lastOne] = result[lastOne].TrimEnd(' ');

        return string.Join('\n', result);
    }
}