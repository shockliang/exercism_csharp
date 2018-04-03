using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        var letters = new ConcurrentDictionary<char, int>();

        Parallel.ForEach(texts, (text) =>
        {
            lock (text)
            {
                var letterGroup = text.ToLower().Where(char.IsLetter).GroupBy(c => c);
                foreach (var item in letterGroup)
                {
                    if (letters.ContainsKey(item.Key))
                        letters[item.Key] += item.Count();
                    else
                        letters.TryAdd(item.Key, item.Count());
                }
            }
        });

        return letters.ToDictionary(kvp => kvp.Key,
                                    kvp => kvp.Value);
    }
}