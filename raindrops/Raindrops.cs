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
        var factorSounds = mapping.Keys
            .Where(factor => (number % factor) == 0)
            .Select(factor => mapping[factor])
            .DefaultIfEmpty(number.ToString());
        return String.Join("", factorSounds);
    }
}