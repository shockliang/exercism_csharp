using System;
using System.Linq;
using System.Collections.Generic;

public static class WordCount
{
    public static IDictionary<string, int> Countwords(string phrase)
    {
        return phrase
                .ToLower()
                .Split(' ', '\n', ',', ':', '.')
                .Where(w => !string.IsNullOrEmpty(w))
                .Aggregate(new Dictionary<string, int>(), (dic, word) =>
                {
                    if (word.StartsWith('\'') && word.EndsWith('\''))
                        word = new string(word.Where(char.IsLetterOrDigit).ToArray());
                    else if (!word.Contains('\''))
                        word = new string(word.Where(char.IsLetterOrDigit).ToArray());

                    if (dic.ContainsKey(word))
                        dic[word]++;
                    else
                        dic.Add(word, 1);
                    return dic;
                });
    }
}