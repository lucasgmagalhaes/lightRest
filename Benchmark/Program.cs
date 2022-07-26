// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using LightRest;
using RestSharp;

[MemoryDiagnoser]
public class Md5VsSha256
{
    private LightRest.LightClient light;
    private RestClient rest;


    public Md5VsSha256()
    {
        light = new LightRest.LightClient();
        rest = new RestClient();
    }

    [Benchmark]
    public async Task Light()
    {
        await light.GetAsync("http://www.contoso.com/");
    }

    [Benchmark]
    public async Task RestSharp()
    {
        await rest.GetAsync(new RestRequest("http://www.contoso.com/"));
    }

}

public class Program
{
    public static async Task Main(string[] args)
    {
        BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}