using System;
using System.Linq;
using System.Collections.Generic;

public class NucleotideCount
{
    public NucleotideCount(string sequence)
    {
        var sequenceToUpper = sequence.ToUpper();
        if (sequenceToUpper.Count(c => !"ATCG".Contains(c)) > 0)
            throw new InvalidNucleotideException();

        NucleotideCounts = new Dictionary<char, int>();
        NucleotideCounts.Add('A', sequenceToUpper.Count(c => c == 'A'));
        NucleotideCounts.Add('C', sequenceToUpper.Count(c => c == 'C'));
        NucleotideCounts.Add('G', sequenceToUpper.Count(c => c == 'G'));
        NucleotideCounts.Add('T', sequenceToUpper.Count(c => c == 'T'));
    }

    public IDictionary<char, int> NucleotideCounts
    {
        get;
    }
}

public class InvalidNucleotideException : Exception { }
