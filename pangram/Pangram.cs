using System;
using System.Collections.Generic;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        var ascillCodeOfLowerAlphabet = Enumerable.Range(97, 26);
        var letters = input.ToLower().Where(x => char.IsLetter(x)).Select(x => Convert.ToInt32(x));
        return ascillCodeOfLowerAlphabet.Except(letters).Count() == 0;
    }
}
