``` ini

BenchmarkDotNet=v0.10.12, OS=macOS 10.12.6 (16G1212) [Darwin 16.7.0]
Intel Core i7-4770HQ CPU 2.20GHz (Haswell), 1 CPU, 8 logical cores and 4 physical cores
.NET Core SDK=2.0.3
  [Host]     : .NET Core 2.0.3 (Framework 4.6.0.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.3 (Framework 4.6.0.0), 64bit RyuJIT


```
|                           Method |   N |           Mean |         Error |        StdDev |
|--------------------------------- |---- |---------------:|--------------:|--------------:|
|   **CalculateSquareOfSum_UsingLinq** |  **10** |     **729.989 ns** |    **14.4367 ns** |    **21.1612 ns** |
|  CalculateSquareOfSum_UsingGauss |  10 |     296.606 ns |     5.8243 ns |     5.7202 ns |
|  CalculateSumOfSquares_UsingLinq |  10 |     791.216 ns |    12.7662 ns |    11.3169 ns |
| CalculateSumOfSquares_UsingGauss |  10 |       4.510 ns |     0.1276 ns |     0.1949 ns |
|   **CalculateSquareOfSum_UsingLinq** | **303** | **312,265.193 ns** | **6,208.5228 ns** | **7,390.8048 ns** |
|  CalculateSquareOfSum_UsingGauss | 303 |  10,913.548 ns |   209.1186 ns |   214.7493 ns |
|  CalculateSumOfSquares_UsingLinq | 303 | 343,212.731 ns | 6,800.5932 ns | 9,533.4819 ns |
| CalculateSumOfSquares_UsingGauss | 303 |     114.084 ns |     1.9650 ns |     1.8381 ns |
