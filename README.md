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

As mentioned, the goal of this library is only to be a lightweight version of the amazing RestSharp lib
and to encapsulate the native class `HttpClient` that the .NET already has.

The above table shows a benchmark between `LightRest`, `RestSharp` and the native `HttpClient`, where
a GET request is made to an API which returns a response with `100ms` of delay per request.

Two tests were made: One with a `1kb` response size. and another one with a `103.27kb` response size

All tests were made with the following configs:

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 2600, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.401
  [Host]     : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT
  DefaultJob : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT

```

#### 1kb response size

In comparison, LightRest is **1,25%** faster than RestSharp, but allocates **87,1%** less memory.

|     Method |     Mean |   Error |  StdDev | Allocated |
|----------- |---------:|--------:|--------:|----------:|
| HttpClient | 103.3 ms | 1.17 ms | 0.98 ms |      7 KB |
|  LightRest | 103.5 ms | 1.46 ms | 1.36 ms |      7 KB |
|  RestSharp | 104.0 ms | 1.62 ms | 1.51 ms |     65 KB |


#### 103.27kb response size


|     Method |     Mean |   Error |  StdDev | Allocated |
|----------- |---------:|--------:|--------:|----------:|
| HttpClient | 107.6 ms | 1.30 ms | 1.15 ms |    444 KB |
|  LightRest | 107.4 ms | 1.43 ms | 1.34 ms |    445 KB |
|  RestSharp | 107.9 ms | 1.26 ms | 1.17 ms |  1,264 KB |

In this case, lightRest still is faster (**0.83%**), but had a reduction in allocation percentile compared to the first test (**64,91%**).
In relation to the `HttpClient` itself, you may notice that the difference between it and lightRest is basically irrelevant.