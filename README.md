# LightRest

[![.NET](https://github.com/lucasgmagalhaes/lightRest/actions/workflows/dotnet.yml/badge.svg)](https://github.com/lucasgmagalhaes/lightRest/actions/workflows/dotnet.yml)

## Motivation

This lib is indeed to be a lightweight alternative for RestSharp. It **DOES NOT** intend to be a directly
concurrent of RestSharp. Only to be an possible alternative for simple scenarios. This way, do not 
expect great features or treatments in this lib, only a simple, request-response with serialization/deserialization
of provided parameters and a HttpCode return.


## Goal

The project goal is to proportionate a wrapper for the well known `HttpClient` and as light as possible. The response of all requests 
are a tuple with the response (as `string` or serialized in a given type), and the HttpStatusCode. To reduce in maximum the memory allocation 
made.


## Features

All http methods has both `async` and `sync` versions. They include:

- `POST`
- `GET`
- `PUT`
- `HEAD`
- `DELETE`
- `PATCH`

In each method, can be passed a pure URL, with a given body (or not), or can be passed using
the class `HttpRequest`. 

## Benchmark

As mentioned, the goal of this library is only to be a lightweight version of the amazing RestSharp lib
and to encapsulate the native class `HttpClient` that the .NET already has.

The benchmark was made comparing `RestSharp` and the `HttpClient` itself.
But the `HttpClient` used an "common" implementation for data fetch that is 
mostly used in applications. The implementation isn't equal to the one made by `LightRest`. It was done intensionally to show how even a "default" usage of the `HttpClient` can be improved.

The print above shows the implementation used for `HttpClient`:

All tests were made with the following configs:

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 2600, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.401
  [Host]     : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT
  DefaultJob : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT

```
|     Method | Count |     Mean |     Error |    StdDev |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|----------- |------ |---------:|----------:|----------:|---------:|---------:|---------:|----------:|
| **HttpClient** |     **1** | **1.292 ms** | **0.0337 ms** | **0.0967 ms** |        **-** |        **-** |        **-** |      **4 KB** |
|  LightRest |     1 | 1.235 ms | 0.0243 ms | 0.0307 ms |        - |        - |        - |      4 KB |
|  RestSharp |     1 | 1.330 ms | 0.0264 ms | 0.0396 ms |   9.7656 |        - |        - |     34 KB |
| **HttpClient** |    **10** | **1.288 ms** | **0.0254 ms** | **0.0402 ms** |        **-** |        **-** |        **-** |      **8 KB** |
|  LightRest |    10 | 1.249 ms | 0.0243 ms | 0.0250 ms |        - |        - |        - |      5 KB |
|  RestSharp |    10 | 1.401 ms | 0.0275 ms | 0.0385 ms |   9.7656 |        - |        - |     41 KB |
| **HttpClient** |   **100** | **1.725 ms** | **0.0342 ms** | **0.0562 ms** |  **15.6250** |        **-** |        **-** |     **64 KB** |
|  LightRest |   100 | 1.707 ms | 0.0336 ms | 0.0493 ms |   3.9063 |        - |        - |     20 KB |
|  RestSharp |   100 | 1.791 ms | 0.0310 ms | 0.0380 ms |  35.1563 |   3.9063 |        - |    143 KB |
| **HttpClient** |  **1000** | **5.152 ms** | **0.1005 ms** | **0.1535 ms** | **132.8125** |  **85.9375** |  **70.3125** |    **574 KB** |
|  LightRest |  1000 | 4.298 ms | 0.0836 ms | 0.1350 ms |  31.2500 |   7.8125 |        - |    157 KB |
|  RestSharp |  1000 | 5.518 ms | 0.1048 ms | 0.1207 ms | 273.4375 | 164.0625 | 125.0000 |  1,104 KB |