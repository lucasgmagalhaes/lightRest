``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 2600, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.302
  [Host]     : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT
  DefaultJob : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT


```
|    Method |     Mean |    Error |   StdDev |   Median | Allocated |
|---------- |---------:|---------:|---------:|---------:|----------:|
|     Light | 212.3 ms |  4.06 ms |  6.19 ms | 211.7 ms |     14 KB |
| RestSharp | 389.2 ms | 11.29 ms | 31.08 ms | 379.3 ms |  1,241 KB |
