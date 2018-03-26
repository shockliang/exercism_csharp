using System;
using System.Linq;
using System.Collections.Generic;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase <= 1 || inputDigits.Any(x => x >= inputBase || x < 0) || outputBase <= 1)
        {
            throw new ArgumentException();
        }

        var outputReuslt = new List<int>();
        var quotient = ToBase10(inputBase, inputDigits);
        
        while (quotient > 0)
        {
            outputReuslt.Add(quotient % outputBase);
            quotient /= outputBase;
        }

        return outputReuslt.ToArray().Reverse().DefaultIfEmpty(0).ToArray();
    }

    private static int ToBase10(int inputBase, int[] inputDigits)
    {
        return inputDigits
                .Reverse()
                .Select((digit, idx) => (int)Math.Pow(inputBase, idx) * digit)
                .Sum();
    }
}