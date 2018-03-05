using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class ProteinTranslation
{
    public static string[] Translate(string codons)
    {
        return Enumerable.Range(0, codons.Length / 3)
            .Select(i => codons.Substring(i * 3, 3))
            .ProteinMap()
            .ToArray();
    }

    private static IEnumerable<string> ProteinMap(this IEnumerable<string> codons)
    {
        foreach (var codon in codons)
        {
            if ("AUG" == codon)
                yield return "Methionine";
            else if (Regex.IsMatch(codon, "UU[CU]"))
                yield return "Phenylalanine";
            else if (Regex.IsMatch(codon, "UU[AG]"))
                yield return "Leucine";
            else if (Regex.IsMatch(codon, "UC[UCAG]"))
                yield return "Serine";
            else if (Regex.IsMatch(codon, "UA[UC]"))
                yield return "Tyrosine";
            else if (Regex.IsMatch(codon, "UG[UC]"))
                yield return "Cysteine";
            else if ("UGG" == codon)
                yield return "Tryptophan";
            else if (Regex.IsMatch(codon, "UA[AG]|UGA"))
                yield break;
            else
                throw new Exception();
        }
    }
}