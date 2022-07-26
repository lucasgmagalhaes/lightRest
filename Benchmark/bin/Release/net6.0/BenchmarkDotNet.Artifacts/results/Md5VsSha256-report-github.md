``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 2600, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.302
  [Host]     : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT
  DefaultJob : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT


```
|    Method |       Mean |    Error |   StdDev | Allocated |
|---------- |-----------:|---------:|---------:|----------:|
|     Light |   597.0 ms |  8.92 ms |  7.45 ms |     14 KB |
| RestSharp | 1,100.8 ms | 21.79 ms | 35.80 ms |  1,278 KB |
