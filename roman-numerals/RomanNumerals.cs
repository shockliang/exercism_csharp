using System;
using System.Linq;
using System.Collections.Generic;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        if ((value < 0) || (value > 3999)) throw new ArgumentOutOfRangeException();
        if (value < 1) return string.Empty;
        if (value >= 1000) return "M" + (value - 1000).ToRoman();
        if (value >= 900) return "CM" + (value - 900).ToRoman();
        if (value >= 500) return "D" + (value - 500).ToRoman();
        if (value >= 400) return "CD" + (value - 400).ToRoman();
        if (value >= 100) return "C" + (value - 100).ToRoman();
        if (value >= 90) return "XC" + (value - 90).ToRoman();
        if (value >= 50) return "L" + (value - 50).ToRoman();
        if (value >= 40) return "XL" + (value - 40).ToRoman();
        if (value >= 10) return "X" + (value - 10).ToRoman();
        if (value >= 9) return "IX" + (value - 9).ToRoman();
        if (value >= 5) return "V" + (value - 5).ToRoman();
        if (value >= 4) return "IV" + (value - 4).ToRoman();
        if (value >= 1) return "I" + (value - 1).ToRoman();
        throw new ArgumentOutOfRangeException();
    }
}