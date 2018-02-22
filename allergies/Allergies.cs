using System;
using System.Collections.Generic;

public class Allergies
{
    int map = 0xFF, results;
    string[] allergyMap = new string[] {"eggs", "peanuts", "shellfish", "strawberries",
        "tomatoes", "chocolate", "pollen", "cats"};
    List<string> allergyItems;

    public Allergies(int mask)
    {
        results = mask & map;
        allergyItems = new List<string>();

        for (int i = 0; i < 8; i++)
        {
            if ((results & 0x01) != 0)
            {
                allergyItems.Add(allergyMap[i]);
            }

            results >>= 1;
        }
    }

    public bool IsAllergicTo(string allergy)
    {
        return allergyItems.Contains(allergy);
    }

    public IList<string> List()
    {
        return allergyItems;
    }
}