```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3775)
Unknown processor
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method              | Mean     | Error   | StdDev  | Gen0    | Allocated |
|-------------------- |---------:|--------:|--------:|--------:|----------:|
| FindWords           | 382.1 μs | 2.88 μs | 2.69 μs | 23.9258 | 440.28 KB |
| WeakWordFinder_Find | 129.6 μs | 2.54 μs | 2.37 μs |       - |   1.84 KB |
