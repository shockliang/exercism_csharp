using System;

public class Clock : IEquatable<Clock>
{
    public Clock(int hours, int minutes)
    {
        Hours = HoursParser(hours, minutes);
        Minutes = MinutesParser(minutes);
    }

    public int Hours { get; private set; }

    public int Minutes { get; private set; }

    public Clock Add(int minutesToAdd)
    {
        Hours = HoursParser(Hours, Minutes + minutesToAdd);
        Minutes = MinutesParser(Minutes + minutesToAdd);
        return this;
    }

    public bool Equals(Clock other)
    {
        return this.ToString().Equals(other.ToString());
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public override string ToString()
    {
        return $"{Hours.ToString("D2")}:{Minutes.ToString("D2")}";
    }

    private int HoursParser(int hours, int minutes)
    {
        if (minutes >= 60)
        {
            hours += minutes / 60;
        }
        else if (minutes < 0)
        {
            hours -= (Math.Abs((minutes / 60)) + 1);
        }

        if (hours >= 0)
        {
            hours %= 24;
        }
        else
        {
            if (hours % 24 == 0)
                hours = 0;
            else
                hours = 24 + (hours % 24);
        }

        return hours;
    }

    private int MinutesParser(int minutes)
    {
        return minutes >= 0 ? minutes % 60 : 60 + (minutes % 60);
    }
}