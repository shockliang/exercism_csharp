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

        var outputReuslt = inputDigits.Length == 0 || (inputDigits.Where(x => x == 0).Count() == inputDigits.Length)
                            ? new List<int>(new int[] { 0 })
                            : new List<int>();
        var quotient = ToBase10(inputBase, inputDigits);
        while (quotient > 0)
        {
            var remainder = 0;
            quotient = Math.DivRem(quotient, outputBase, out remainder);
            outputReuslt.Add(remainder);
        }

        return outputReuslt.ToArray().Reverse().ToArray();
    }

    private static int ToBase10(int inputBase, int[] inputDigits)
    {
        int base10Value = 0;
        var inputDigitsLBS = inputDigits.Reverse().ToArray();
        for (int i = 0; i < inputDigitsLBS.Count(); i++)
        {
            base10Value += ((int)Math.Pow(inputBase, i) * inputDigitsLBS[i]);
        }
        return base10Value;
    }
}