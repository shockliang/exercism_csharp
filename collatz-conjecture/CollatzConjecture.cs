using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number < 1) throw new ArgumentException();
        if (number == 1) return 0;
        return 1 + Steps(number % 2 == 0 ? number / 2 : number * 3 + 1);
    }
}