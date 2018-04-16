using System;
using System.Linq;
using System.Collections.Generic;

public static class Luhn
{
    public static bool IsValid(string number)
    {
        if (!number.All(c => char.IsDigit(c) || char.IsWhiteSpace(c)) ||
            number.Trim().Length <= 1)
            return false;

        return number
            .Where(char.IsDigit)
            .Select(c => c - '0')
            .Reverse()
            .Select((digit, i) => ((i + 1) % 2 == 0) ? digit * 2 : digit)
            .Select(digit => digit > 9 ? digit - 9 : digit)
            .Sum() % 10 == 0;
    }
}