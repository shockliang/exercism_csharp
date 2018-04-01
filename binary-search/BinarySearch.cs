using System;
using System.Linq;
using System.Collections.Generic;

public class BinarySearch
{
    private readonly int[] input;
    public BinarySearch(int[] input)
    {
        this.input = input;
    }

    public int Find(int value)
    {
        var count = 0;
        var mid = input.Length % 2 == 0 ? (input.Length / 2) + 1 : input.Length / 2;
        var previous = input.Length;
        while (true && input.Length > 0)
        {
            var midElement = input[mid];
            if (midElement == value)
            {
                return mid;
            }
            else if (midElement > value)
            {
                previous = mid;
                mid /= 2;
            }
            else
            {
                mid = ((previous - mid) / 2) + mid;
            }

            if (count++ == input.Length) { break; }
        }
        return -1;
    }
}