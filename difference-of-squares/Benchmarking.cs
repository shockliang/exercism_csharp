using BenchmarkDotNet.Attributes;

public class Benchmarking
{
    /// <summary>
    /// 304 will trigger overflow expception cause over the int max limitation.
    /// </summary>
    [Params(10, 303)]
    public int N;

    [Benchmark]
    public void CalculateSquareOfSum_UsingLinq()
    {
        for (int i = 1; i < N; i++)
        {
            DifferenceOfSquares.CalculateSquareOfSum(i);
        }
    }

    [Benchmark]
    public void CalculateSquareOfSum_UsingGauss()
    {
        for (int i = 1; i < N; i++)
        {
            DifferenceOfSquaresGauss.CalculateSquareOfSum(i);
        }
    }

    [Benchmark]
    public void CalculateSumOfSquares_UsingLinq()
    {
        for (int i = 1; i < N; i++)
        {
            DifferenceOfSquares.CalculateSumOfSquares(i);
        }
    }

    [Benchmark]
    public void CalculateSumOfSquares_UsingGauss()
    {
        for (int i = 1; i < N; i++)
        {
            DifferenceOfSquaresGauss.CalculateSumOfSquares(i);
        }
    }

}