using System;

public class SpaceAge
{
    private static readonly double EARTH_YEAR = 31557600d;
    private static readonly double MERCURY_YEAR = EARTH_YEAR * 0.2408467d;
    private static readonly double VENUS_YEAR = EARTH_YEAR * 0.61519726d;
    private static readonly double MARS_YEAR = EARTH_YEAR * 1.8808158d;
    private static readonly double JUPITER_YEAR = EARTH_YEAR * 11.862615d;
    private static readonly double SATURN_YEAR = EARTH_YEAR * 29.447498d;
    private static readonly double URANUS_YEAR = EARTH_YEAR * 84.016846d;
    private static readonly double NEPTUNE_YEAR = EARTH_YEAR * 164.79132d;

    private readonly double seconds;

    private readonly int roundDigits = 2;

    public SpaceAge(long seconds)
    {
        this.seconds = (double)seconds;
    }

    public double OnEarth()
    {
        return Math.Round(seconds / EARTH_YEAR, roundDigits);
    }

    public double OnMercury()
    {
        return Math.Round(seconds / MERCURY_YEAR, roundDigits);
    }

    public double OnVenus()
    {
        return Math.Round(seconds / VENUS_YEAR, roundDigits);
    }

    public double OnMars()
    {
        return Math.Round(seconds / MARS_YEAR, roundDigits);
    }

    public double OnJupiter()
    {
        return Math.Round(seconds / JUPITER_YEAR, roundDigits);
    }

    public double OnSaturn()
    {
        return Math.Round(seconds / SATURN_YEAR, roundDigits);
    }

    public double OnUranus()
    {
        return Math.Round(seconds / URANUS_YEAR, roundDigits);
    }

    public double OnNeptune()
    {
        return Math.Round(seconds / NEPTUNE_YEAR, roundDigits);
    }
}