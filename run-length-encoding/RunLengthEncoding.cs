using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.String;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (IsNullOrEmpty(input))
            return Empty;

        var encoded = new StringBuilder();
        var repeat = 0;
        var temp = input.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).First();

        for (int i = 0; i < input.Length; i++)
        {
            var c = input[i];
            if (temp.Equals(c))
            {
                repeat++;
            }
            else
            {
                encoded.Append(repeat == 1 ? Convert.ToString(temp) : $"{repeat}{temp}");

                temp = c;
                repeat = 1;
            }

            if (i == input.Length - 1)
                encoded.Append(repeat == 1 ? Convert.ToString(temp) : $"{repeat}{temp}");
        }
        return encoded.ToString();
    }

    public static string Decode(string input)
    {
        if (IsNullOrEmpty(input))
            return Empty;

        var digit = new StringBuilder();
        var decoded = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            var c = input[i];
            if (char.IsDigit(c))
                digit.Append(c);

            if (char.IsLetter(c) || char.IsWhiteSpace(c))
            {
                var repeat = digit.Length > 0 ? Convert.ToInt32(digit.ToString()) : 0;
                decoded.Append(repeat == 0 ? Convert.ToString(c) : new String(c, repeat));
                digit.Clear();
            }
        }

        return decoded.ToString();
    }
}
