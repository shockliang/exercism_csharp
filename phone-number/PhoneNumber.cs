using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        phoneNumber = new string(phoneNumber.Where(x => char.IsDigit(x)).ToArray());
        if (!IsValidNumberLength(phoneNumber))
            throw new ArgumentException();

        phoneNumber = phoneNumber.Length == 10 ? phoneNumber.Insert(0, "1") : phoneNumber;
        var digits = phoneNumber.Select(x => int.Parse(x.ToString())).ToArray();
        var isValidCountryCode = digits[0] == 1;
        var isValidAreaCode = IsValidRegualNumberRange(digits[1]);
        var isValidExchangeCode = IsValidRegualNumberRange(digits[4]);

        return isValidCountryCode && isValidAreaCode && isValidExchangeCode
                    ? phoneNumber.TrimStart('1') : throw new ArgumentException();
    }

    private static bool IsValidNumberLength(string phoneNumber)
    {
        return phoneNumber.Length > 9 && phoneNumber.Length < 12;
    }

    private static bool IsValidRegualNumberRange(int digit)
    {
        return digit > 1 && digit < 9;
    }

}