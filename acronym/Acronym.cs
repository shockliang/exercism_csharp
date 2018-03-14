using System;
using System.Linq;
using System.Collections.Generic;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var letters = phrase.Split(' ').Select(x => x.FirstOrDefault()).ToArray();

        if (phrase.Contains(':'))
            letters = phrase.Substring(0, phrase.IndexOf(':')).ToArray();

        if (phrase.Contains('-'))
            letters = phrase.Split(new char[] { ' ', '-' }).Select(x => x.FirstOrDefault()).ToArray();

        return new string(letters).ToUpper();
    }
}