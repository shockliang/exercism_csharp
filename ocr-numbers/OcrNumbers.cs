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
        var result = input.Split("\n").ToArray();
        var nums = new List<string>();
        var rows = new List<string[]>();

        for (int i = 0; i < result.Length; i += 4)
        {
            rows.Add(result.Skip(i).Take(4).ToArray());
        }

        foreach (var row in rows)
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
                if (patterns.ContainsKey(key))
                    singleRow.Add(patterns[key]);
                else
                    singleRow.Add("?");
            }
            nums.Add(string.Concat(singleRow));
        }

        return string.Join(",", nums);
    }
}