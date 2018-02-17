using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var copyNumber = number;
        var power = number.ToString().Length;
        var sum = 0d;
        
        while (copyNumber > 0)
        {
            sum += Math.Pow(copyNumber % 10, power);
            copyNumber /= 10;
        }

        return sum == number;
    }
}