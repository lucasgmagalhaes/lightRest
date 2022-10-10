using LightRest.Testing.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LightRest.Test;

public class LightClientTest
{
    private LightClient _light { get; set; }
    private const string GET_URL = "http://localhost/games";
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        var clientOptions = new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = true,
            BaseAddress = new Uri("http://localhost"),
            HandleCookies = true,
            MaxAutomaticRedirections = 7
        };

        var application = new WebApplicationFactory<Program>()
       .WithWebHostBuilder(builder =>
       {
       });

        _client = application.CreateClient(clientOptions);
        _light = new LightClient(_client);
    }

    [Test]
    public async Task GetAsync_ShouldGet_String()
    {
        var (response, code) = await _light.GetAsync(GET_URL);
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.NotNull(response);
        Assert.That(response.Replace("\n", ""), Is.EqualTo(@"[{""id"":1,""title"":""elden ring""}]"));
    }

    [Test]
    public async Task GetAsync_ShouldGet_Serialized()
    {
        var (response, code) = await _light.GetAsync<List<Game>>(GET_URL);
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.NotNull(response);
        Assert.That(response[0].Id, Is.EqualTo(1));
        Assert.That(response[0].Title, Is.EqualTo("elden ring"));
    }

    [Test]
    public async Task GetAsync_Should_Post_String()
    {
        var game = new Game
        {
            Title = "game test",
        };
        _light.SetMediaType("application/json");
        var (response, code) = await _light.PostAsync(GET_URL, JsonSerializer.Serialize(game));
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.IsEmpty(response);
    }
}
