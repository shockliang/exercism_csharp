using System;
using System.Linq;
using System.Collections.Generic;

public static class ProteinTranslation
{
    private static readonly IDictionary<string, string> translation = new Dictionary<string, string>()
    {
        ["AUG"] = "Methionine",
        ["UUU"] = "Phenylalanine",
        ["UUC"] = "Phenylalanine",
        ["UUA"] = "Leucine",
        ["UUG"] = "Leucine",
        ["UCU"] = "Serine",
        ["UCC"] = "Serine",
        ["UCA"] = "Serine",
        ["UCG"] = "Serine",
        ["UAU"] = "Tyrosine",
        ["UAC"] = "Tyrosine",
        ["UGU"] = "Cysteine",
        ["UGC"] = "Cysteine",
        ["UGG"] = "Tryptophan",
        ["UAA"] = "STOP",
        ["UAG"] = "STOP",
        ["UGA"] = "STOP",
    };
    public static string[] Translate(string codon)
    {
        codon = codon.ToUpper();
        var codons = new List<string>();

        for (int i = 0; i < codon.Length; i += 3)
        {
            var singleCodon = new string(codon.Skip(i).Take(3).ToArray());
            if (translation.ContainsKey(singleCodon))
            {
                if(translation[singleCodon].Equals("STOP"))
                    break;
                else
                    codons.Add(translation[singleCodon]);
            }
        }
        return codons.Count > 0 ? codons.ToArray() : throw new Exception();
    }
}