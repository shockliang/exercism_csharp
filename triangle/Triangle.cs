using System;
using System.Linq;
using System.Collections.Generic;

// For a shape to be a triangle at all, all sides have to be of length > 0,
// and the sum of the lengths of any two sides must be greater than or equal to the length of the third side.
public static class Triangle
{
    // A scalene triangle has all sides of different lengths
    public static bool IsScalene(double side1, double side2, double side3)
    {
        var sides = new double[] { side1, side2, side3 };
        return IsValidSides(sides) &&
                sides.Distinct().Count() == 3;
    }

    // An isosceles triangle has at least two sides the same length.
    public static bool IsIsosceles(double side1, double side2, double side3)
    {
        var sides = new double[] { side1, side2, side3 };
        return IsValidSides(sides) &&
                sides.Distinct().Count() == 2 ||
                sides.Distinct().Count() == 1;
    }

    // An equilateral triangle has all three sides the same length
    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        var sides = new double[] { side1, side2, side3 };
        return IsValidSides(sides) &&
                sides.Distinct().Count() == 1;
    }

    private static bool IsAllGreatThanZero(IEnumerable<double> sides)
    {
        return sides.Count() == 3 && sides.All(side => side > 0);
    }
    private static bool IsValidSides(IEnumerable<double> sides)
    {
        return IsAllGreatThanZero(sides) &&
                sides.Max() <= sides.Sum() / 2;
    }
}

public class TriangleException : Exception { }