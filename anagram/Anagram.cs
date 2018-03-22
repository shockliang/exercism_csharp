using System;
using System.Linq;
using System.Collections.Generic;

public class Anagram
{
    private readonly string baseWord;
    public Anagram(string baseWord)
    {
        this.baseWord = baseWord;
    }

    public string[] Anagrams(string[] potentialMatches)
    {
        return potentialMatches
        .Where(w => w.Length == baseWord.Length)
        .Where(w => !w.ToLower().Equals(baseWord.ToLower()))
        .Aggregate(new List<string>(), (list, word) =>
        {
            var isMatch = word.All(c => 
            {
                return word.ToLower().Count(x => c == x) == baseWord.ToLower().Count(x => c == x);
            });

            if (isMatch)
                list.Add(word);
            return list;
        })
        .ToArray();
    }
}