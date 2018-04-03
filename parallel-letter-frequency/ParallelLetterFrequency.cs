using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        var letters = new ConcurrentDictionary<char, int>();

        Parallel.ForEach(texts, (text) =>
        {
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                    letters.AddOrUpdate(char.ToLower(c), 1, (k, v) => v + 1);
            }
        });

        return letters.ToDictionary(x => x.Key, x => x.Value);
    }
}