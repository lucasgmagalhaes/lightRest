using LightRest.Testing.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using System.Text.Json;

namespace LightRest.Test;

public class LightClientTest
{
    private LightClient _light;

    private LightClient _clientObj { get => (LightClient)_light; }

    private const string API_URL = "http://localhost/api/games";
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
    public void AddDefaultHeader_Should_Set_Header()
    {
        _light.AddDefaultHeader("test", "val");
        var keyValue = _clientObj._client.DefaultRequestHeaders.FirstOrDefault();
        Assert.Multiple(() =>
        {
            Assert.That(1, Is.EqualTo(_clientObj._client.DefaultRequestHeaders.Count()));
            Assert.That("test", Is.EqualTo(keyValue.Key));
            Assert.That("val", Is.EqualTo(keyValue.Value.FirstOrDefault()));
            Assert.That(1, Is.EqualTo(keyValue.Value.Count()));
        });
    }

    [Test]
    public void AddDefaultHeader_Should_Set_Header_With_Multiple_Value()
    {
        _light.AddDefaultHeader("test", new[] { "val1", "val2" });
        var keyValue = _clientObj._client.DefaultRequestHeaders.FirstOrDefault();
        Assert.Multiple(() =>
        {
            Assert.That(1, Is.EqualTo(_clientObj._client.DefaultRequestHeaders.Count()));
            Assert.That("test", Is.EqualTo(keyValue.Key));
            Assert.That("val1", Is.EqualTo(keyValue.Value.FirstOrDefault()));
            Assert.That("val2", Is.EqualTo(keyValue.Value.ToArray()[1]));
            Assert.That(2, Is.EqualTo(keyValue.Value.Count()));
        });
    }

    [Test]
    public void ClearDefaultHeaders_Should_Clear_Headers()
    {
        _light.AddDefaultHeader("test", "val");
        Assert.That(1, Is.EqualTo(_clientObj._client.DefaultRequestHeaders.Count()));
        _light.ClearDefaultHeaders();
        Assert.That(0, Is.EqualTo(_clientObj._client.DefaultRequestHeaders.Count()));
    }

    [Test]
    public void SetBaseUrl_Should_Set_Base_Url()
    {
        var url = "http://localhost/2";
        _light.SetBaseUrl(url);
        Assert.That(_clientObj?._client?.BaseAddress?.AbsoluteUri, Is.EqualTo(url));
    }

    [Test]
    public void SetEncoding_Should_SetEncoding()
    {
        _light.SetEncoding(Encoding.Unicode);
        Assert.That(_clientObj._encoding, Is.EqualTo(Encoding.Unicode));
    }

    [Test]
    public void SetMediaType_Should_Set_Media_Type()
    {
        var media = "text";
        _light.SetMediaType(media);
        Assert.That(_clientObj._mediaType, Is.EqualTo(media));
    }

    [Test]
    public void SetSerializerOptions_Should_Set_Serialization()
    {
        var serializer = new JsonSerializerOptions();
        _light.SetSerializerOptions(serializer);
        Assert.That(JsonSerializer.Serialize(_clientObj._serializerOptions), 
            Is.EqualTo(JsonSerializer.Serialize(serializer)));
    }

    [Test]
    public async Task GetAsync_ShouldGet_String()
    {
        var (response, code) = await _light.GetAsync(API_URL);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Not.Null);
        });
        Assert.That(response?.Replace("\n", ""), Is.EqualTo(@"[{""id"":1,""title"":""elden ring""}]"));
    }

    [Test]
    public async Task GetAsync_ShouldGet_Serialized()
    {
        var (response, code) = await _light.GetAsync<List<Game>>(API_URL);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Not.Null);
        });
        Assert.Multiple(() =>
        {
            Assert.That(response?[0].Id, Is.EqualTo(1));
            Assert.That(response?[0].Title, Is.EqualTo("elden ring"));
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
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Empty);
        });
    }

    [Test]
    public async Task GetAsync_Should_Post_Without_Body()
    {
        var (response, code) = await _light.PostAsync(API_URL + "/post-empty");
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Empty);
        });
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
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Empty);
        });
    }

    [Test]
    public async Task GetAsync_Should_Put_Object()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PutAsync(API_URL + "/1", game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Empty);
        });
    }

    [Test]
    public async Task GetAsync_Should_Put_Without_Body()
    {
        var (response, code) = await _light.PutAsync(API_URL + "/put-empty");
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Empty);
        });
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
        var (response, code) = await _light.PatchAsync(API_URL + "/1", JsonSerializer.Serialize(game));
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Empty);
        });
    }

    [Test]
    public async Task GetAsync_Should_Patch_Object()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PatchAsync(API_URL + "/1", game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Empty);
        });
    }

    #endregion
}
