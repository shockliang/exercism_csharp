using System;
using System.Linq;
using System.Collections.Generic;

public static class BeerSong
{
    public static string Verse(int number) => Verses(number, number);

    public static string Verses(int begin, int end)
    {
        var steps = Enumerable.Range(end, (begin - end) + 1).Reverse();
        var allVerses = steps.Select(x =>
        {
            var firstUnit = x == 1 ? $"{x} bottle" : $"{x} bottles";
            var secondUnit = x - 1 == 1 ? $"{x - 1} bottle" : $"{x - 1} bottles";
            var first = x == 0 ?
                            $"No more bottles of beer on the wall, no more bottles of beer." :
                            $"{firstUnit} of beer on the wall, {firstUnit} of beer.";
            var second = x - 1 == 0 ?
                            $"Take it down and pass it around, no more bottles of beer on the wall." :
                            $"Take one down and pass it around, {secondUnit} of beer on the wall.";
            second = x - 1 < 0 ?
                            "Go to the store and buy some more, 99 bottles of beer on the wall." :
                            second;
            return string.Join("\n", new string[] { first, second, "" });
        });

        return string.Join("\n", allVerses); ;
    }
}