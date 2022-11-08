// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using RestSharp;
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

    private const string URL = "https://jsonplaceholder.typicode.com/todos";

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
        var response = await client.GetAsync(URL);
        _ = JsonSerializer.Deserialize<List<ResponseExample>>(await response.Content.ReadAsStringAsync());
    }

    [Benchmark]
    public async Task LightRest()
    {
        var req = new HttpRequest(URL, HttpMethod.Get);
        _ = await light.SendAsync(req);
    }

    [Benchmark]
    public async Task RestSharp()
    {
        var req = new RestRequest(URL);
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