using System;
using System.Linq;
using System.Collections.Generic;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        var result = text
            .Select((c) =>
            {
                if (char.IsLetter(c))
                {
                    var converted = Convert.ToChar((c + (shiftKey % 26)));
                    if ((char.IsLower(c) && converted > 'z') ||
                        (char.IsUpper(c) && converted > 'Z'))
                        return Convert.ToChar(converted - 26);
                    else
                        return converted;
                }
                else
                {
                    return c;
                }
            })
            .ToArray();
        return new string(result);
    }
}