using System;
using System.Linq;
using System.Collections.Generic;

public class RailFenceCipher
{
    private readonly int rails;
    public RailFenceCipher(int rails)
    {
        this.rails = rails;
    }

    public string Encode(string input)
    {
        var encoded = new List<List<char>>();
        for (int i = 0; i < rails; i++)
        {
            encoded.Add(new List<char>());
        }

        var row = 0;
        var dir = 1;

        for (int col = 0; col < input.Length; col++)
        {
            encoded[row].Add(input[col]);

            if (col >= rails - 1)
            {
                if (row == rails - 1)
                {
                    dir = -1;
                    row = rails - 2;
                }
                else if (row == 0)
                {
                    dir = 1;
                    row = 1;
                }
                else
                {
                    row += dir;
                }
            }
            else
            {
                row += dir;
            }
        }

        return string.Concat(encoded.Select(c => string.Concat(c)));
    }

    public string Decode(string input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}