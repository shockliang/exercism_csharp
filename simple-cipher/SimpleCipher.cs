using System;
using System.Linq;
using System.Collections.Generic;
using static System.String;

public class Cipher
{
    public Cipher()
    {
        Key = GenerateRandomKey();
    }

    public Cipher(string key)
    {
        Key = IsNullOrEmpty(key) ||
                key.Where(char.IsUpper).Count() > 0 ||
                key.Where(char.IsDigit).Count() > 0
            ? throw new ArgumentException()
            : key;
    }

    public string Key { get; }

    public string Encode(string plaintext)
    {
        return Concat(plaintext
                .Select((c, idx) => Rollover(c + (Key[idx] - 'a'))));
    }

    public string Decode(string ciphertext)
    {
        return Concat(ciphertext
                .Select((c, idx) =>
                {
                    var shift = (Key[idx] - 'a');
                    var isRollover = (c - shift) < 'a';
                    return isRollover ? (char)('z' - (shift - (c - 'a')) + 1) : (char)(c - shift);
                }));
    }

    private char Rollover(int letter)
    {
        return letter > 'z' ? (char)('a' + letter - 'z' - 1) : (char)letter;
    }

    private string GenerateRandomKey()
    {
        var rand = new Random();
        return Concat(Enumerable.Range(0, 100)
                .Select(i => rand.Next('a', 'z'))
                .Select(x => Convert.ToChar(x)));
    }
}