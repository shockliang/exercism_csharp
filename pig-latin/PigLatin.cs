using System;
using System.Text.RegularExpressions;
using System.Linq;

public static class PigLatin
{
    public static string Translate(string word)
    {
        return Regex.Replace(word, 
            @"\b(ch?|qu?|squ|thr|th|sch|y(?!t)|x(?!r)|[bdfghjklmnprstvwz]{2,}(?=y)|[bdfghjklmnprstvwz])?(\S+)", @"$2$1ay", 
            RegexOptions.IgnoreCase);
    }
}