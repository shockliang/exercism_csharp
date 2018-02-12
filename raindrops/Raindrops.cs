using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Raindrops
{
    private static Dictionary<int, string> mapping = new Dictionary<int, string>()
    {
        [3] = "Pling",
        [5] = "Plang",
        [7] = "Plong"
    };

    public static string Convert(int number)
    {
        var factors = Enumerable.Range(1, number).Where(n => number % n == 0);
        var intersect = factors.Intersect(new int[] { 3, 5, 7 }).OrderBy(x => x);
        var result = new StringBuilder();
        foreach (var factor in intersect)
        {
            result.Append(mapping[factor]);
        }
        
        return result.Length > 0 ? result.ToString() : number.ToString();
    }
}