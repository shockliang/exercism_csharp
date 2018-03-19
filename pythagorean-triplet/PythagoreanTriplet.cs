using System;
using System.Linq;
using System.Collections.Generic;

public class Triplet
{
    private readonly int a;
    private readonly int b;
    private readonly int c;

    private readonly IEnumerable<int> sides;

    public Triplet(int a, int b, int c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        sides = new int[] { a, b, c };
    }

    public int Sum() => sides.Sum();

    public int Product() => sides.Aggregate((result, side) => result * side);

    public bool IsPythagorean() => a * a + b * b == c * c;

    public static IEnumerable<Triplet> Where(int maxFactor, int minFactor = 1, int sum = 0)
    {
        var triplets = new List<Triplet>();
        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                for (int k = j; k <= maxFactor; k++)
                {
                    if (i * i + j * j == k * k)
                    {
                        var triplet = new Triplet(i, j, k);
                        if (triplet.Sum() == sum)
                            triplets.Add(triplet);
                        else if (sum == 0)
                            triplets.Add(triplet);
                    }
                }
            }
        }
        return triplets;
    }
}