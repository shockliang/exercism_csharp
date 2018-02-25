using System;
using System.Linq;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n < 1 || n > 64)
            throw new ArgumentOutOfRangeException();

        return (ulong)1 << (n - 1);
    }

    public static ulong Total()
    {
        return ulong.MaxValue;
    }
}