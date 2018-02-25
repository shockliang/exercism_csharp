using System;
using System.Linq;

public static class Grains
{
    public static ulong Square(int n)
    {
        return (n > 0 && n < 65) ? (ulong)1 << (n - 1) : throw new ArgumentOutOfRangeException();
    }

    public static ulong Total()
    {
        return ulong.MaxValue;
    }
}