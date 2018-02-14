using System;
using System.Linq;
using System.Collections.Generic;

public class NucleotideCount
{
    private IDictionary<char, int> nucleotideCount;
    public NucleotideCount(string sequence)
    {
        nucleotideCount = CalculateNucleotideCount(sequence);
    }

    public IDictionary<char, int> NucleotideCounts => nucleotideCount;

    private IDictionary<char, int> CalculateNucleotideCount(string sequence)
    {
        var result = new Dictionary<char, int>()
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };

        var charArray = sequence.ToUpper().ToCharArray();

        foreach (var c in charArray)
        {
            if (result.ContainsKey(c))
                result[c]++;
            else
                throw new InvalidNucleotideException();
        }

        return result;
    }
}

public class InvalidNucleotideException : Exception { }
