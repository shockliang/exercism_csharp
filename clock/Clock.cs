using System;

public struct Clock : IEquatable<Clock>
{
    int time;
    const int MAX_MINUTES_IN_DAY = 24 * 60;
    public Clock(int hours, int minutes)
    {
        time = (hours * 60 + minutes) % MAX_MINUTES_IN_DAY;
        if (time < 0) time = MAX_MINUTES_IN_DAY + time;
    }

    public int Hours
    {
        get
        {
            return time / 60;
        }
    }

    public int Minutes
    {
        get
        {
            return time % 60;
        }
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(Hours, Minutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(Hours, Minutes - minutesToSubtract);
    }

    public override string ToString()
    {
        return $"{Hours:00}:{Minutes:00}";
    }

    public bool Equals(Clock other)
    {
        return other.Hours == Hours && other.Minutes == Minutes;
    }
}