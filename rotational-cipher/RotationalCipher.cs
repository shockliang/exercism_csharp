using System;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        return String.Concat(text.Select(c =>
        {
            if (Char.IsLetter(c))
            {
                var offset = Char.IsUpper(c) ? 'A' : 'a';
                var o = (char)(c + shiftKey % 26);
                return (o - offset) < 26 ? o : (char)(o - 26);
            }
            return c;
        }));
    }
}