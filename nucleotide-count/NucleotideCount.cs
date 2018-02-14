using System;
using System.Linq;
using System.Collections.Generic;

public class NucleotideCount
{
    public NucleotideCount(string sequence)
    {
        if (sequence.Count(c => !"ATCG".Contains(c)) > 0)
            throw new InvalidNucleotideException();

        NucleotideCounts = new Dictionary<char, int>();
        NucleotideCounts['A'] = 0;
        NucleotideCounts['T'] = 0;
        NucleotideCounts['C'] = 0;
        NucleotideCounts['G'] = 0;
        sequence.ToUpper()
            .Where(c => "ATCG".Contains(c))
            .ToList()
            .ForEach(c => NucleotideCounts[c]++);
    }

    public IDictionary<char, int> NucleotideCounts
    {
        get;
    }
}

public class InvalidNucleotideException : Exception { }
