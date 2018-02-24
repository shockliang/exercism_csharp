``` ini

BenchmarkDotNet=v0.10.12, OS=macOS 10.12.6 (16G1212) [Darwin 16.7.0]
Intel Core i7-4770HQ CPU 2.20GHz (Haswell), 1 CPU, 8 logical cores and 4 physical cores
.NET Core SDK=2.0.3
  [Host]     : .NET Core 2.0.3 (Framework 4.6.0.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.3 (Framework 4.6.0.0), 64bit RyuJIT


```
|                           Method |   N |           Mean |         Error |         StdDev |
|--------------------------------- |---- |---------------:|--------------:|---------------:|
|   **CalculateSquareOfSum_UsingLinq** |  **10** |     **720.066 ns** |    **14.0213 ns** |     **23.0374 ns** |
|  CalculateSquareOfSum_UsingGauss |  10 |     294.505 ns |     5.8648 ns |      9.7988 ns |
|  CalculateSumOfSquares_UsingLinq |  10 |     809.200 ns |    15.9506 ns |     16.3801 ns |
| CalculateSumOfSquares_UsingGauss |  10 |       4.600 ns |     0.1277 ns |      0.1195 ns |
|   **CalculateSquareOfSum_UsingLinq** | **303** | **308,316.095 ns** | **6,089.4568 ns** |  **9,833.3376 ns** |
|  CalculateSquareOfSum_UsingGauss | 303 |  10,863.038 ns |   214.4793 ns |    314.3810 ns |
|  CalculateSumOfSquares_UsingLinq | 303 | 342,967.425 ns | 6,695.1393 ns | 11,000.3058 ns |
| CalculateSumOfSquares_UsingGauss | 303 |     117.067 ns |     2.3625 ns |      3.3119 ns |
