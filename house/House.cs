using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public static class House
{
    public static string Recite(int startVerse, int endVerse)
    {
        var mapping = new Dictionary<int, string>()
        {
            [1] = "the house that Jack built.",
            [2] = "the malt\nthat lay in ",
            [3] = "the rat\nthat ate ",
            [4] = "the cat\nthat killed ",
            [5] = "the dog\nthat worried ",
            [6] = "the cow with the crumpled horn\nthat tossed ",
            [7] = "the maiden all forlorn\nthat milked ",
            [8] = "the man all tattered and torn\nthat kissed ",
            [9] = "the priest all shaven and shorn\nthat married ",
            [10] = "the rooster that crowed in the morn\nthat woke ",
            [11] = "the farmer sowing his corn\nthat kept ",
            [12] = "the horse and the hound and the horn\nthat belonged to "
        };

        var verses = new List<string>();
        for (int i = startVerse; i <= endVerse; i++)
        {
            var verse = new StringBuilder("This is ");
            for (int j = i; j > 0; j--)
            {
                verse.Append(mapping[j]);
            }

            verses.Add(verse.ToString());
        }

        var result = string.Join("\n\n", verses);
        return string.Join("\n\n", verses);
    }
}