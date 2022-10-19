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
    private const string API_URL = "http://localhost/games";
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
        _light.SetMediaType("application/json");
    }

    [Test]
    public async Task GetAsync_ShouldGet_String()
    {
        var (response, code) = await _light.GetAsync(API_URL);
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.NotNull(response);
        Assert.That(response.Replace("\n", ""), Is.EqualTo(@"[{""id"":1,""title"":""elden ring""}]"));
    }

    [Test]
    public async Task GetAsync_ShouldGet_Serialized()
    {
        var (response, code) = await _light.GetAsync<List<Game>>(API_URL);
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(response[0].Id, Is.EqualTo(1));
            Assert.That(response[0].Title, Is.EqualTo("elden ring"));
        });
    }

    #region POST
    [Test]
    public async Task GetAsync_Should_Post_String()
    {
        var game = new Game
        {
            Title = "game test",
        };        
        var (response, code) = await _light.PostAsync(API_URL, JsonSerializer.Serialize(game));
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response, Is.Empty);
    }

    [Test]
    public async Task GetAsync_Should_Post_Object()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PostAsync<int>(API_URL, game);
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response, Is.Empty);
    }

    [Test]
    public async Task GetAsync_Should_Post_Without_Body()
    {
        var (response, code) = await _light.PostAsync(API_URL + "/post-empty");
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response, Is.Empty);
    }

    #endregion

    #region PUT

    [Test]
    public async Task GetAsync_Should_Put_String()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PutAsync(API_URL + "/1", JsonSerializer.Serialize(game));
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response, Is.Empty);
    }

    [Test]
    public async Task GetAsync_Should_Put_Object()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PutAsync(API_URL + "/1", game);
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response, Is.Empty);
    }

    [Test]
    public async Task GetAsync_Should_Put_Without_Body()
    {
        var (response, code) = await _light.PutAsync(API_URL + "/put-empty");
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response, Is.Empty);
    }

    #endregion

    #region PATCH

    [Test]
    public async Task GetAsync_Should_Patch_String()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PutAsync(API_URL + "/1", JsonSerializer.Serialize(game));
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response, Is.Empty);
    }

    [Test]
    public async Task GetAsync_Should_Patch_Object()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PutAsync(API_URL + "/1", game);
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response, Is.Empty);
    }

    [Test]
    public async Task GetAsync_Should_Patch_Without_Body()
    {
        var (response, code) = await _light.PatchAsync(API_URL + "/put-empty");
        Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response, Is.Empty);
    }

    #endregion
}
