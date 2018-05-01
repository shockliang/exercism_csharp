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

        var increment = 1;

        for (int row = 0, col = 0; col < input.Length; col++)
        {
            encoded[row].Add(input[col]);
            (row, increment) = NextBoundary(row, increment);
        }

        return string.Concat(encoded.Select(c => string.Concat(c)));
    }

    public string Decode(string input)
    {
        var decoded = BuildMatrix(input.Length);
        var increment = 1;
        var idx = 0;
        for (int currentRow = 0; currentRow < decoded.Count; currentRow++)
        {
            increment = 1;
            for (int row = 0, col = 0; col < input.Length; col++)
            {
                if (row == currentRow)
                    decoded[row][col] = input[idx++];
                (row, increment) = NextBoundary(row, increment);
            }
        }

        var decodedString = new List<char>();
        increment = 1;
        for (int row = 0, col = 0; col < input.Length; col++)
        {
            decodedString.Add(decoded[row][col]);
            (row, increment) = NextBoundary(row, increment);
        }

        return string.Concat(decodedString);
    }

    private (int row, int increment) NextBoundary(int currentRow, int currentIncrement)
    {
        var row = currentRow;
        var increment = currentIncrement;

        if (row + increment == rails || row + increment == -1)
            increment *= -1;

        row += increment;

        return (row: row, increment: increment);
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