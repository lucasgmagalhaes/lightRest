// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using RestSharp;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LightRest.Benchmark;

public class ResponseExample
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("completed")]
    public bool Completed { get; set; }
}

[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
public class Md5VsSha256
{
    private ILightClient light;
    private RestClient rest;
    private HttpClient client;

    private const string URL = "http://localhost:49154/todos";

    [Params(1, 10, 100, 1000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        light = new LightClient();
        rest = new RestClient();
        client = new HttpClient();
    }

    [Benchmark]
    public async Task HttpClient()
    {
        var response = await client.GetAsync(URL + $"/{Count}");
        var str = await response.Content.ReadAsStringAsync();
        _ = JsonSerializer.Deserialize<List<ResponseExample>>(str);
    }

    [Benchmark]
    public async Task LightRest()
    {
        _ = await light.GetAsync<List<ResponseExample>>(URL + $"/{Count}");
    }

    [Benchmark]
    public async Task RestSharp()
    {
        var req = new RestRequest(URL + $"/{Count}");
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