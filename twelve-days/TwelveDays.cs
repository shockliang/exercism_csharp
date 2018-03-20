using System;
using System.Collections.Generic;
using System.Linq;

public static class TwelveDaysSong
{
    private static Dictionary<int, Tuple<string, string>> verses = new Dictionary<int, Tuple<string, string>>()
    {
        {1, new Tuple<string,string>("first", "a Partridge in a Pear Tree.")},
        {2, new Tuple<string,string>("second", "two Turtle Doves, and ")},
        {3, new Tuple<string,string>("third", "three French Hens, ")},
        {4, new Tuple<string,string>("fourth", "four Calling Birds, ")},
        {5, new Tuple<string,string>("fifth", "five Gold Rings, ")},
        {6, new Tuple<string,string>("sixth", "six Geese-a-Laying, ")},
        {7, new Tuple<string,string>("seventh", "seven Swans-a-Swimming, ")},
        {8, new Tuple<string,string>("eighth", "eight Maids-a-Milking, ")},
        {9, new Tuple<string,string>("ninth", "nine Ladies Dancing, ")},
        {10, new Tuple<string,string>("tenth", "ten Lords-a-Leaping, ")},
        {11, new Tuple<string,string>("eleventh", "eleven Pipers Piping, ")},
        {12, new Tuple<string,string>("twelfth", "twelve Drummers Drumming, ")},
    };
    public static string Sing() => Verses(1, 12);

    public static string Verse(int verseNumber)
    {
        return $"On the {verses[verseNumber].Item1} day of Christmas my true love gave to me, " +
            String.Concat(Enumerable.Range(1, verseNumber)
                .OrderByDescending(x => x)
                .Select(i => verses[i].Item2)) + "\n";
    }

    public static string Verses(int start, int end)
    {
        return String.Concat(Enumerable.Range(start, end - start + 1).Select(i => Verse(i) + "\n"));
    }
}