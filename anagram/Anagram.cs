using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{

  private string BaseWord;
  private IEnumerable<char> BaseCharacters;

  public Anagram(string baseWord)
  {
    BaseWord = baseWord.ToLower();
    BaseCharacters = BaseWord.ToLower().OrderBy(c => c);
  }

  public string[] Anagrams(string[] potentialMatches)
  {
    return potentialMatches
        .Where(pm =>
        {
          string pmLower = pm.ToLower();
          return pmLower != BaseWord && pmLower.OrderBy(c => c).SequenceEqual(BaseCharacters);
        })
        .ToArray();
  }
}