using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public static class TwelveDaysSong
{
    public static string Sing() => string.Join("", Verses(1, 12));

    public static string Verse(int verseNumber)
    {
        var verses = new StringBuilder($"On the {ConvertDigitToOrdinal(verseNumber)} day of Christmas my true love gave to me, ");

        for (int i = verseNumber; i >= 1; i--)
        {
            var symbol = i == 1 ? ".\n" : ", ";
            var gift = verseNumber > 1 && i == 1
                ? $"and {DayOfGift(i)}{symbol}"
                : $"{DayOfGift(i)}{symbol}";

            verses.Append(gift);
        }

        return verses.ToString();
    }

    public static string Verses(int start, int end)
    {
        return string.Join("", Enumerable.Range(start, end - start + 1)
                                .Select(i => Verse(i))
                                .Select(verse => $"{verse}\n"));
    }

    private static string ConvertDigitToOrdinal(int i)
    {
        switch (i)
        {
            case 1: return "first";
            case 2: return "second";
            case 3: return "third";
            case 4: return "fourth";
            case 5: return "fifth";
            case 6: return "sixth";
            case 7: return "seventh";
            case 8: return "eighth";
            case 9: return "ninth";
            case 10: return "tenth";
            case 11: return "eleventh";
            case 12: return "twelfth";
            default:
                throw new IndexOutOfRangeException();
        }
    }

    private static string DayOfGift(int i)
    {
        switch (i)
        {
            case 1: return "a Partridge in a Pear Tree";
            case 2: return "two Turtle Doves";
            case 3: return "three French Hens";
            case 4: return "four Calling Birds";
            case 5: return "five Gold Rings";
            case 6: return "six Geese-a-Laying";
            case 7: return "seven Swans-a-Swimming";
            case 8: return "eight Maids-a-Milking";
            case 9: return "nine Ladies Dancing";
            case 10: return "ten Lords-a-Leaping";
            case 11: return "eleven Pipers Piping";
            case 12: return "twelve Drummers Drumming";
            default:
                throw new IndexOutOfRangeException();
        }
    }
}