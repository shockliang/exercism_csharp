using System;
using System.Linq;
using System.Collections.Generic;

public static class Change
{
    public static int[] Calculate(int target, int[] coins)
    {
        if (coins.Any(coin => coin == target))
            return new int[] { target };
        if (target == 0)
            return new int[0];
        if (coins.All(coin => coin > target && target > 0) || target < 0)
            throw new ArgumentException();

        var combinations = new List<List<int>>();
        var filtered = coins.Where(coin => coin < target).Reverse();

        for (int i = 0; i < filtered.Count(); i++)
        {
            var list = filtered.Skip(i).Take(filtered.Count() - i).ToList();
            var changes = new List<int>();
            var remainder = target;
            var j = 0;
            while (remainder > 0)
            {
                if (remainder >= list[j])
                {
                    remainder -= list[j];
                    changes.Add(list[j]);
                }
                else
                {
                    j++;
                }
            }
            changes.Reverse();
            combinations.Add(changes);
        }

        return combinations.OrderBy(x => x.Count).FirstOrDefault().ToArray();
    }
}