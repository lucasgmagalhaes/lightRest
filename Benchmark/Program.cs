// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
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

    private const string URL = "https://jsonplaceholder.typicode.com/todos";

    public Md5VsSha256()
    {
        light = new LightClient();
        rest = new RestClient();
    }

    [Benchmark]
    public async Task Light_With_HttpRequest_Class()
    {
        var req = new HttpRequest(URL, HttpMethod.Get);
        req.AddHeader("v1", "2");
        _ = await light.SendAsync(req);
    }

    [Benchmark]
    public async Task Light_Directly()
    {
        _ = await light.GetAsync(URL);
    }

    [Benchmark]
    public async Task Light_Directly_With_Serialization()
    {
        _ = await light.GetAsync<List<ResponseExample>>(URL);
    }

    [Benchmark]
    public async Task RestSharp()
    {
        var req = new RestRequest(URL);
        req.AddHeader("v1", "2");
        _ = await rest.GetAsync(req);
    }

    [Benchmark]
    public async Task RestSharp_WithSerialization()
    {
        var req = new RestRequest(URL);
        req.AddHeader("v1", "2");
        _ = await rest.GetAsync<List<ResponseExample>>(req);
    }

}

public static class Program
{
    public static void Main(string[] _)
    {
        BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}