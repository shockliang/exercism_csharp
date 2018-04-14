using System;
using System.Linq;
using System.Collections.Generic;

public static class OcrNumbers
{
    private static IDictionary<string, string> patterns = new Dictionary<string, string>()
    {
        [" _ | ||_|"] = "0",
        ["     |  |"] = "1",
        [" _  _||_ "] = "2",
        [" _  _| _|"] = "3",
        ["   |_|  |"] = "4",
        [" _ |_  _|"] = "5",
        [" _ |_ |_|"] = "6",
        [" _   |  |"] = "7",
        [" _ |_||_|"] = "8",
        [" _ |_| _|"] = "9"
    };

    public static string Convert(string input)
    {
        return string.Join(",", Enumerable
            .Range(0, input.Split("\n").Length)
            .Where(i => i % 4 == 0)
            .Select(i => input.Split("\n").Skip(i).Take(4).ToArray())
            .Select(row =>
            {
                if (row.Length < 4 || row.First().Count() % 3 != 0)
                    throw new ArgumentException();

                var singleRow = new List<string>();
                for (int i = 0; i < row.First().Count(); i += 3)
                {
                    var key = string.Concat(
                        row[0].Skip(i).Take(3).Concat(
                        row[1].Skip(i).Take(3)).Concat(
                        row[2].Skip(i).Take(3)));

                    singleRow.Add(patterns.ContainsKey(key) ? patterns[key] : "?");
                }

                return string.Concat(singleRow);
            }));
    }
}