```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3775)
Unknown processor
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method              | Mean     | Error   | StdDev  | Allocated |
|-------------------- |---------:|--------:|--------:|----------:|
| FindWords           | 100.6 μs | 0.83 μs | 0.77 μs |   1.02 KB |
| WeakWordFinder_Find | 127.5 μs | 1.27 μs | 1.12 μs |   1.84 KB |
