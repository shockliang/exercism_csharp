``` ini

BenchmarkDotNet=v0.10.12, OS=macOS 10.12.6 (16G1212) [Darwin 16.7.0]
Intel Core i7-4770HQ CPU 2.20GHz (Haswell), 1 CPU, 8 logical cores and 4 physical cores
.NET Core SDK=2.0.3
  [Host]     : .NET Core 2.0.3 (Framework 4.6.0.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.3 (Framework 4.6.0.0), 64bit RyuJIT


```
|                           Method |   N |           Mean |         Error |        StdDev |
|--------------------------------- |---- |---------------:|--------------:|--------------:|
|   **CalculateSquareOfSum_UsingLinq** |  **10** |     **737.784 ns** |    **12.4384 ns** |    **11.6349 ns** |
|  CalculateSquareOfSum_UsingGauss |  10 |       4.653 ns |     0.1144 ns |     0.1070 ns |
|  CalculateSumOfSquares_UsingLinq |  10 |     809.048 ns |    12.4410 ns |    15.2787 ns |
| CalculateSumOfSquares_UsingGauss |  10 |       4.558 ns |     0.1296 ns |     0.1331 ns |
|   **CalculateSquareOfSum_UsingLinq** | **303** | **304,148.978 ns** | **6,000.9783 ns** | **5,011.0882 ns** |
|  CalculateSquareOfSum_UsingGauss | 303 |     117.144 ns |     2.1891 ns |     2.0477 ns |
|  CalculateSumOfSquares_UsingLinq | 303 | 355,930.957 ns | 5,999.0862 ns | 5,611.5484 ns |
| CalculateSumOfSquares_UsingGauss | 303 |     117.511 ns |     1.1476 ns |     1.0173 ns |
