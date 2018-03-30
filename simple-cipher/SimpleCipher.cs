using System;
using System.Linq;
using System.Text;
using static System.String;

public class Cipher
{
    public Cipher()
        : this(GenerateRandomKey())
    {
    }

    private static string GenerateRandomKey()
    {
        var rand = new Random();
        return Concat(Enumerable.Range(0, 100)
                .Select(i => rand.Next('a', 'z'))
                .Select(x => Convert.ToChar(x)));
    }

    public Cipher(string key)
    {
        Key = key.Any() && key.All(c => c >= 'a' && c <= 'z') ? key : throw new ArgumentException();
    }
    
    public string Key { get; private set; }

    public string Encode(string plaintext)
    {
        return Shift(plaintext, Key, 1);
    }

    public string Decode(string ciphertext)
    {
        return Shift(ciphertext, Key, -1);
    }

    private static string Shift(string input, string key, int sign)
    {
        var shiftedChars = input
            .Zip(key, (c,k) => Shift(c, k, sign))
            .ToArray();
        return new string(shiftedChars);
    }

    private static char Shift(char input, char key, int sign)
    {
        int charAsInt = input - 'a';
        int shiftBy = (key - 'a') * sign;
        int shiftedValue = charAsInt + shiftBy + 26;
        int indexInAlphabet = shiftedValue % 26;
        return (char)('a' + indexInAlphabet);
    }
}