using System;

// For a shape to be a triangle at all, all sides have to be of length > 0,
// and the sum of the lengths of any two sides must be greater than or equal to the length of the third side.
public static class Triangle
{
    // A scalene triangle has all sides of different lengths
    public static bool IsScalene(double side1, double side2, double side3)
    {
        return IsValidSides(side1, side2, side3) &&
                side1 != side2 && side2 != side3 && side3 != side1;
    }

    // An isosceles triangle has at least two sides the same length.
    public static bool IsIsosceles(double side1, double side2, double side3)
    {
        return IsValidSides(side1, side2, side3) &&
                ((side1 == side2) ||
                (side2 == side3) ||
                (side3 == side1));
    }

    // An equilateral triangle has all three sides the same length
    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        return IsValidSides(side1, side2, side3) &&
                (side1 == side2 && side2 == side3 && side1 == side3);
    }

    private static bool IsAllGreatThanZero(double side1, double side2, double side3)
    {
        return side1 > 0 && side2 > 0 && side3 > 0;
    }
    private static bool IsValidSides(double side1, double side2, double side3)
    {
        return IsAllGreatThanZero(side1, side2, side3) &&
                (side1 + side2 >= side3 &&
                side2 + side3 >= side1 &&
                side3 + side1 >= side2);
    }
}

public class TriangleException : Exception { }