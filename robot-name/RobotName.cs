using System;
using System.Linq;
using System.Collections.Generic;

public class Robot
{
    private static IDictionary<string, List<int>> tags = new Dictionary<string, List<int>>();

    private static IList<string> letterIds;
    static Robot()
    {
        var azLetters = Enumerable.Range(65, 26).Select(x => Convert.ToChar(x));
        letterIds = azLetters.Aggregate(new List<string>(), (result, first) =>
        {
            result.AddRange(azLetters.Select(second => $"{first}{second}"));
            return result;
        });

        foreach (var item in letterIds)
        {
            tags.Add(item, null);
        }
    }

    private string letterId;
    private int digitId;

    public Robot()
    {
        Name = GetName();
    }

    public string Name { get; private set; }

    public void Reset()
    {
        tags[letterId].Add(digitId);
        Name = GetName();
    }

    private string GetName()
    {
        var rand = new Random();
        letterId = letterIds[rand.Next(0, letterIds.Count)];

        if (tags[letterId] == null)
            tags[letterId] = Enumerable.Range(0, 999).ToList();

        var digitIds = tags[letterId];
        var randDigitIndex = rand.Next(0, digitIds.Count);
        digitId = digitIds[randDigitIndex];
        digitIds.Remove(digitId);
        
        return $"{letterId}{digitId:D3}";
    }
}