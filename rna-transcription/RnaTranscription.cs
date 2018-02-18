using System;
using System.Linq;
using System.Collections.Generic;

public static class RnaTranscription
{
    private static readonly IDictionary<char, char> mapping = new Dictionary<char, char>()
    {
        ['G'] = 'C',
        ['C'] = 'G',
        ['T'] = 'A',
        ['A'] = 'U'
    };
    
    public static string ToRna(string nucleotide)
    {
        return new string(nucleotide.ToUpper().Select(c => mapping[c]).ToArray());
    }
}