using System;

public struct Clock
{
    public Clock(int hours, int minutes)
    {
        Hours = hours + Math.DivRem(minutes, 60, out int m);
        Minutes = m;

        if (Minutes < 0)
        {
            Minutes += 60;
            Hours--;
        }

        Hours %= 24;

        if (Hours < 0) Hours += 24;
    }

    public int Hours { get; }

    public int Minutes { get; }

    public Clock Add(int minutesToAdd) => new Clock(Hours, Minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => Add(-minutesToSubtract);

    public override string ToString() => $"{Hours:00}:{Minutes:00}";
}