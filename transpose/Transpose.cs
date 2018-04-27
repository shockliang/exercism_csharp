using System;
using System.Linq;
using System.Collections.Generic;

public static class Transpose
{
    public static string String(string input)
    {
        var lines = input.Split('\n');

        var transposed = Enumerable.Range(0, lines.Max(x => x.Length))
            .Select(x => new List<char>(Enumerable.Repeat(' ', lines.Count()))).ToList();

        for (int i = 0; i < lines.Count(); i++)
        {
            for (int j = 0; j < lines[i].Count(); j++)
            {
                transposed[j][i] = lines[i][j];
            }
        }

        return string.Join('\n', transposed.Select(x => string.Concat(x))).TrimEnd();
    }
}