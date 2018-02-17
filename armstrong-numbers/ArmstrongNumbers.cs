using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int power = (int)Math.Ceiling(Math.Log10(number));
        return number
            .ToString()
            .Sum(e => Math.Pow((int)char.GetNumericValue(e), power)) == number;
    }
}