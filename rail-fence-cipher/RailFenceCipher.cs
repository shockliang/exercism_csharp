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
        var encoded = BuildMatrix();

        var dir = 1;

        for (int row = 0, col = 0; col < input.Length; col++)
        {
            encoded[row].Add(input[col]);

            if (row == rails - 1)
            {
                dir = -1;
                row = rails - 2;
            }
            else if (row == 0 && col != 0)
            {
                dir = 1;
                row = 1;
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
        var decoded = BuildMatrix(input.Length);
        var dir = 1;
        var idx = 0;
        for (int currentRow = 0; currentRow < decoded.Count; currentRow++)
        {
            dir = 1;
            for (int row = 0, col = 0; col < input.Length; col++)
            {
                if (row == currentRow)
                    decoded[row][col] = input[idx++];

                if (row == rails - 1)
                {
                    dir = -1;
                    row = rails - 2;
                }
                else if (row == 0 && col != 0)
                {
                    dir = 1;
                    row = 1;
                }
                else
                {
                    row += dir;
                }
            }
        }

        var decodedString = new List<char>();
        dir = 1;
        for (int row = 0, col = 0; col < input.Length; col++)
        {
            decodedString.Add(decoded[row][col]);
            if (row == rails - 1)
            {
                dir = -1;
                row = rails - 2;
            }
            else if (row == 0 && col != 0)
            {
                dir = 1;
                row = 1;
            }
            else
            {
                row += dir;
            }
        }

        return string.Concat(decodedString);
    }

    private List<List<char>> BuildMatrix(int length = 0)
    {
        var encoded = new List<List<char>>();
        for (int i = 0; i < rails; i++)
        {
            encoded.Add(new List<char>(Enumerable.Repeat(' ', length)));
        }
        return encoded;
    }
}