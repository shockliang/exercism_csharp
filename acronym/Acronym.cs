using System;
using System.Linq;
using System.Collections.Generic;

public static class Acronym
{
    public static string Abbreviate(string phrase) 
        => new string(phrase.Split(' ', '-').Select(s => char.ToUpper(s[0])).ToArray());
}