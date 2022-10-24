# LightRest

[![.NET](https://github.com/lucasgmagalhaes/lightRest/actions/workflows/dotnet.yml/badge.svg)](https://github.com/lucasgmagalhaes/lightRest/actions/workflows/dotnet.yml)

## Motivation

This lib is indead to be a lightweight alternative for RestSharp. It **DOES NOT** intend to be a directly
concurrent of RestSharp. Only to be an possible alternative for simple scenarios. This way, do not 
spect great features or threatments in this lib, only a simple, request-response with serialization/deserialization
of provided parameters and a HttpCode return.

## Features

All http methods are `async` as default. They include:

- POST
- GET
- PUT
- HEAD
- DELETE
- PATCH

In each method, can be passed a pure URL, with a given body (or not), or can be passed using
the class `HttpRequest`. 

## Benchmark

As mentioned, the goal of this library is only to be a lightweight version of the amazin RestSharp version
and to encapsulate the native class `HttpClient` that the .NET already has.

The above table shows a benchmark between `LightRest`, `RestSharp` and the native `HttpClient`:

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 2600, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.401
  [Host]     : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT
  DefaultJob : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT


```
|                                      Method |     Mean |    Error |    StdDev |   Median | Allocated |
|-------------------------------------------- |---------:|---------:|----------:|---------:|----------:|
| LightRest_HttpRequest_Without_Serialization | 163.7 ms |  1.69 ms |   1.50 ms | 163.4 ms |    109 KB |
|    LightRest_Directly_Without_Serialization | 178.1 ms |  3.47 ms |   3.56 ms | 177.5 ms |    109 KB |
|       LightRest_Directly_With_Serialization | 163.1 ms |  2.96 ms |   2.77 ms | 162.7 ms |    142 KB |
|             RestSharp_Without_Serialization | 341.5 ms | 17.12 ms |  47.71 ms | 327.7 ms |    279 KB |
|                RestSharp_With_Serialization | 327.9 ms | 35.07 ms | 101.18 ms | 350.1 ms |    338 KB |