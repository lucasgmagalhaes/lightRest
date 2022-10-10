// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using LightRest;
using RestSharp;
using System.Text.Json.Serialization;

namespace LightRest.Benchmark;

public class ResponseExample
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("completed")]
    public bool Completed { get; set; }
}

[MemoryDiagnoser]
public class Md5VsSha256
{
    private LightClient light;
    private RestClient rest;


    public Md5VsSha256()
    {
        light = new LightClient();
        rest = new RestClient();
    }

    [Benchmark]
    public async Task Light_With_HttpRequest_Class()
    {
        var req = new HttpRequest();
        req.SetUrl("https://jsonplaceholder.typicode.com/todos/1");
        req.AddHeader("v1", "2");
        _ = await light.GetAsync(req);
    }

    [Benchmark]
    public async Task Light_Directly()
    {
        _ = await light.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
    }

    [Benchmark]
    public async Task Light_Directly_With_Serialization()
    {
        _ = await light.GetAsync<ResponseExample>("https://jsonplaceholder.typicode.com/todos/1");
    }

    [Benchmark]
    public async Task RestSharp()
    {
        var req = new RestRequest("https://jsonplaceholder.typicode.com/todos/1");
        req.AddHeader("v1", "2");
        _ = await rest.GetAsync(req);
    }

    [Benchmark]
    public async Task RestSharp_WithSerialization()
    {
        var req = new RestRequest("https://jsonplaceholder.typicode.com/todos/1");
        req.AddHeader("v1", "2");
        _ = await rest.GetAsync<ResponseExample>(req);
    }

}

public static class Program
{
    public static void Main(string[] _)
    {
        BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}