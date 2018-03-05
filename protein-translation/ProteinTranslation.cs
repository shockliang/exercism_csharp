using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class ProteinTranslation
{
    public static string[] Translate(string codons)
    {
        if (!Regex.IsMatch(codons, @"^[AUCG]+$"))
            throw new Exception();

        var codonToProtein = new Dictionary<string[], string>
        {
            [new string[] { "AUG" }] = "Methionine",
            [new string[] { "UUU", "UUC" }] = "Phenylalanine",
            [new string[] { "UUA", "UUG" }] = "Leucine",
            [new string[] { "UCU", "UCC", "UCA", "UCG" }] = "Serine",
            [new string[] { "UAU", "UAC" }] = "Tyrosine",
            [new string[] { "UGU", "UGC" }] = "Cysteine",
            [new string[] { "UGG" }] = "Tryptophan",
            [new string[] { "UAA", "UAG", "UGA" }] = "STOP"
        };


        var protein = new List<string>();
        for (int i = 0; i < codons.Length; i += 3)
        {
            var singleCodon = codonToProtein
                                .Where(a => a.Key.Contains(codons.Substring(i, 3)))
                                .Select(a => a.Value).FirstOrDefault();

            if (singleCodon.Equals("STOP"))
            {
                break;
            }
            protein.Add(singleCodon);
        }

        return protein.ToArray();
    }
}