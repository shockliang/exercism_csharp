using System;

public class BinarySearch
{
    private readonly int[] input;

    public BinarySearch(int[] input)
    {
        this.input = input;
    }

    public int Find(int value)
    {
        return Find(value, 0, input.Length);
    }

    private int Find(int value, int startIndex, int endIndex)
    {
        if (endIndex <= startIndex) return -1;

        var mid = startIndex + ((endIndex - startIndex) / 2);
        switch (value.CompareTo(input[mid]))
        {
            case int x when x > 0:
                return Find(value, mid + 1, endIndex);
            case int x when x < 0:
                return Find(value, startIndex, mid);
            default:
                return mid;
        }
    }
}