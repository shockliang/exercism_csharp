using System;

/// <summary>
/// Formula according Gauss. https://brilliant.org/wiki/gauss-the-prince-of-mathematics/
/// </summary>
public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        return Convert.ToInt32(Math.Pow((1 + max) * max / 2, 2));
    }

    public static int CalculateSumOfSquares(int max)
    {
        return Convert.ToInt32((max * (max + 1) * (2 * max + 1)) / 6);
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return Math.Abs(CalculateSumOfSquares(max) - CalculateSquareOfSum(max));
    }
}