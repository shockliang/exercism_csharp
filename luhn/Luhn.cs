using System;
using System.Linq;
using System.Collections.Generic;

public static class Luhn
{
    public static bool IsValid(string number)
    {
        if (number.Where(char.IsDigit).Count() <= 1 ||
            number.Where(c => c != ' ' && c < '0' || c > '9').Count() > 0)
            return false;

        return number
            .Where(char.IsDigit)
            .Select(c => c - '0')
            .Reverse()
            .Select((digit, i) =>
            {
                if ((i + 1) % 2 == 0)
                    return digit * 2 > 9 ? digit * 2 - 9 : digit * 2;
                else
                    return digit;
            })
            .Sum() % 10 == 0;
    }
}