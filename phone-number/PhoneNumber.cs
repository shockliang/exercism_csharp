using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var phone = new string(phoneNumber.Where(char.IsNumber).ToArray());
        if (phone.First() == '1')
        {
            phone = phone.Substring(1);
        }

        return !IsValidPhoneNumber(phone) ? throw new ArgumentException() : phone;
    }

    private static bool IsValidPhoneNumber(string phoneNumber) => Regex.IsMatch(phoneNumber, @"^[2-9][0-9]{2}[2-9][0-9]{6}$");
}