using System;
using System.Linq;
using System.Collections.Generic;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        number = number.ToLower();

        if (Invalid(number))
            return false;

        var digits = number
            .Where(char.IsLetterOrDigit)
            .Select(d =>
            {
                var digit = 0;
                if (char.IsDigit(d))
                    digit = (int)char.GetNumericValue(d);
                else if (d == 'x')
                    digit = 10;
                return digit;
            });

        var digitQueue = new Queue<int>(digits);
        var checkSum = 0;
        for (int i = digitQueue.Count; i > 0; i--)
        {
            checkSum += (digitQueue.Dequeue() * i);
        }

        return checkSum % 11 == 0;
    }

    private static bool Invalid(string number)
    {
        return number.Where(char.IsLetterOrDigit).Count() != 10 ||
                (char.IsLetter(number.Last()) && !number.EndsWith('x')) ||
                (number.Contains('x') && number.IndexOf('x') != number.Length - 1);
    }
}