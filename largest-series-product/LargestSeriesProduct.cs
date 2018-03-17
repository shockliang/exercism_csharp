using System;
using System.Linq;
using System.Collections.Generic;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (IsInvalidValue(digits, span))
            throw new ArgumentException();
        if (IsReportToOne(digits, span))
            return 1L;

        List<long> products = new List<long>();
        var count = digits.Length % span == 0 ? digits.Length : digits.Length - span + 1;
        for (int i = 0; i < count; i++)
        {
            var product = digits
                            .Skip(i).Take(span)
                            .Select(x => long.Parse(char.ToString(x)))
                            .Aggregate((result, digit) => result * digit);
            products.Add(product);
        }
        return products.Max();
    }

    private static bool IsInvalidValue(string digits, int span)
    {
        return digits.Length < span ||
                span < 0 ||
                digits.Where(char.IsDigit).Count() != digits.Length;
    }

    private static bool IsReportToOne(string digits, int span)
    {
        return string.IsNullOrEmpty(digits) && span == 0 ||
                digits.Length > 0 && span == 0;
    }
}