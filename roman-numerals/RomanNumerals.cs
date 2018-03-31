using System;
using System.Linq;
using System.Collections.Generic;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int n, char one, char five, char ten)
    {
        switch (n % 10)
        {
            case 1: return new string(new char[] { one });
            case 2: return new string(new char[] { one, one });
            case 3: return new string(new char[] { one, one, one });
            case 4: return new string(new char[] { one, five });
            case 5: return new string(new char[] { five });
            case 6: return new string(new char[] { five, one });
            case 7: return new string(new char[] { five, one, one });
            case 8: return new string(new char[] { five, one, one, one });
            case 9: return new string(new char[] { one, ten});
        }
        return "";
    }

    public static string ToRoman(this int value)
    {
        List<string> numerals = new List<string>()
        {
            (value / 1000).ToRoman('M', ' ', ' '),
            (value / 100).ToRoman('C', 'D', 'M'),
            (value / 10).ToRoman('X', 'L', 'C'),
            (value / 1).ToRoman('I', 'V', 'X'),
        };

        return string.Join("", numerals);
    }
}