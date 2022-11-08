using LightRest.Testing.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using System.Text.Json;

namespace LightRest.Test;

public class LightClientTest
{
    private ILightClient _light;

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
    public void Should_Init_With_All_Params()
    {
        var client = new LightClient();
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

    #region POST
    [Test]
    public async Task PostAsync_Should_Post_String()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PostAsync(API_URL, game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.EqualTo("{\"id\":2,\"title\":\"game test\"}"));
        });
    }

    [Test]
    public async Task GetAsync_Should_Post_Without_Body()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PostAsync(new Uri(API_URL), game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.EqualTo("{\"id\":2,\"title\":\"game test\"}"));
        });
    }

    [Test]
    public async Task PostAsync_Should_Post_String_With_Response_Serialization()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PostAsync<Game>(API_URL, game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JsonSerializer.Serialize(response), Is.EqualTo("{\"id\":2,\"title\":\"game test\"}"));
        });
    }

    [Test]
    public async Task GetAsync_Should_Post_Without_Body_Response_Serialization()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PostAsync<Game>(new Uri(API_URL), game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JsonSerializer.Serialize(response), Is.EqualTo("{\"id\":2,\"title\":\"game test\"}"));
        });
    }

    #endregion

    #region DELETE

    [Test]
    public async Task DeleteAsync_Should_SendDelete_By_String_Url()
    {
        var (response, code) = await _light.DeleteAsync(API_URL + "/1");
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.EqualTo("{\"id\":1,\"title\":\"elden ring\"}"));
        });
    }

    [Test]
    public async Task DeleteAsync_Should_SendDelete_By_Uri_Url()
    {
        var (response, code) = await _light.DeleteAsync(new Uri(API_URL + "/1"));
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.EqualTo("{\"id\":1,\"title\":\"elden ring\"}"));
        });
    }

    [Test]
    public async Task DeleteAsync_Should_SendDelete_By_String_Url_And_Serialializing()
    {
        var (response, code) = await _light.DeleteAsync<Game>(API_URL + "/1");
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JsonSerializer.Serialize(response), Is.EqualTo("{\"id\":1,\"title\":\"elden ring\"}"));
        });
    }

    [Test]
    public async Task DeleteAsync_Should_SendDelete_By_Uri_Url_And_Serializing()
    {
        var (response, code) = await _light.DeleteAsync<Game>(new Uri(API_URL + "/1"));
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JsonSerializer.Serialize(response), Is.EqualTo("{\"id\":1,\"title\":\"elden ring\"}"));
        });
    }

    #endregion

    #region PUT

    [Test]
    public async Task PutAsync_Should_Put_Send_Using_String()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PutAsync(API_URL + "/1", game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.EqualTo("{\"id\":1,\"title\":\"game test\"}"));
        });
    }

    [Test]
    public async Task PutAsync_Should_Put_Send_Using_Uri()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PutAsync(new Uri(API_URL + "/1"), game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.EqualTo("{\"id\":1,\"title\":\"game test\"}"));
        });
    }

    [Test]
    public async Task PutAsync_Should_Put_Send_Using_String_And_Serializing()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PutAsync<Game>(API_URL + "/1", game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JsonSerializer.Serialize(response), Is.EqualTo("{\"id\":1,\"title\":\"game test\"}"));
        });
    }

    [Test]
    public async Task PutAsync_Should_Put_Send_Using_Uri_And_Serializing()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PutAsync<Game>(new Uri(API_URL + "/1"), game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JsonSerializer.Serialize(response), Is.EqualTo("{\"id\":1,\"title\":\"game test\"}"));
        });
    }

    #endregion

    #region PATCH

    [Test]
    public async Task PatchAsync_Should_Patch_String()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PatchAsync(API_URL + "/1", game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.EqualTo("{\"id\":1,\"title\":\"elden ring\"}"));
        });
    }

    [Test]
    public async Task PatchAsync_Should_Patch_Object()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PatchAsync(new Uri(API_URL + "/1") , game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.EqualTo("{\"id\":1,\"title\":\"elden ring\"}"));
        });
    }

    [Test]
    public async Task PatchAsync_Should_Patch_Uri_Serializing()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PatchAsync<Game>(API_URL + "/1", game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JsonSerializer.Serialize(response), Is.EqualTo("{\"id\":1,\"title\":\"elden ring\"}"));
        });
    }

    [Test]
    public async Task PatchAsync_Should_Patch_String_Serializing()
    {
        var game = new Game
        {
            Title = "game test",
        };
        var (response, code) = await _light.PatchAsync<Game>(new Uri(API_URL + "/1"), game);
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JsonSerializer.Serialize(response), Is.EqualTo("{\"id\":1,\"title\":\"elden ring\"}"));
        });
    }

    #endregion

    #region GET

    [Test]
    public async Task GetAsync_Should_Send_Get_By_String_Url()
    {
        var (response, code) = await _light.GetAsync(API_URL + "/1");
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.EqualTo("{\"id\":1,\"title\":\"elden ring\"}"));
        });
    }

    [Test]
    public async Task GetAsync_Should_Send_Get_By_Uri_Url()
    {
        var (response, code) = await _light.GetAsync(new Uri(API_URL + "/1"));
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.EqualTo("{\"id\":1,\"title\":\"elden ring\"}"));
        });
    }

    [Test]
    public async Task GetAsync_Should_Send_Get_By_String_Url_And_Serialializing()
    {
        var (response, code) = await _light.GetAsync<Game>(API_URL + "/1");
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JsonSerializer.Serialize(response), Is.EqualTo("{\"id\":1,\"title\":\"elden ring\"}"));
        });
    }

    [Test]
    public async Task GetAsync_Should_Send_Get_By_Uri_Url_And_Serializing()
    {
        var (response, code) = await _light.GetAsync<Game>(new Uri(API_URL + "/1"));
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JsonSerializer.Serialize(response), Is.EqualTo("{\"id\":1,\"title\":\"elden ring\"}"));
        });
    }

    #endregion

    #region HEAD

    [Test]
    public async Task HeadAsync_Should_Send_Get_By_String_Url()
    {
        var (response, code) = await _light.HeadAsync(API_URL + "/1");
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Empty);
        });
    }

    [Test]
    public async Task HeadAsync_Should_Send_Get_By_Uri_Url()
    {
        var (response, code) = await _light.HeadAsync(new Uri(API_URL + "/1"));
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Empty);
        });
    }

    [Test]
    public async Task HeadAsync_Should_Send_Get_By_String_Url_And_Serialializing()
    {
        var (response, code) = await _light.HeadAsync<string>(API_URL + "/1");
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Empty);
        });
    }

    [Test]
    public async Task HeadAsync_Should_Send_Get_By_Uri_Url_And_Serializing()
    {
        var (response, code) = await _light.HeadAsync<string>(new Uri(API_URL + "/1"));
        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Empty);
        });
    }

    #endregion

    #region SEND



    #endregion

}
