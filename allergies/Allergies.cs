using System;
using System.Collections.Generic;

public class Allergies
{
    private IDictionary<string, int> allergyItem = new Dictionary<string, int>()
    {
        ["eggs"] = 1,
        ["peanuts"] = 2,
        ["shellfish"] = 4,
        ["strawberries"] = 8,
        ["tomatoes"] = 16,
        ["chocolate"] = 32,
        ["pollen"] = 64,
        ["cats"] = 128
    };

    private List<string> allergyItems = new List<string>();

    public Allergies(int mask)
    {
        foreach (var item in allergyItem)
        {
            if ((item.Value & mask) == item.Value)
            {
                allergyItems.Add(item.Key);
            }
        }
    }

    public bool IsAllergicTo(string allergy)
    {
        return allergyItems.IndexOf(allergy) != -1;
    }

    public IList<string> List()
    {
        return allergyItems;
    }
}