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
        _light.MediaType = "application/json";
    }

    [Test]
    public void Should_Init_With_All_Params()
    {
        var jsonOption = new JsonSerializerOptions();
        var client = new LightClient(Encoding.UTF8, jsonOption);
        Assert.That(jsonOption, Is.EqualTo(client.SerializerOptions));
        Assert.That(Encoding.UTF8, Is.EqualTo(client.Encoding));
    }

    [Test]
    public void Should_Init_With_All_Params_With_Base_Url()
    {
        var baseUrl = "http://localhost/";
        var jsonOption = new JsonSerializerOptions();
        var client = new LightClient(baseUrl, Encoding.UTF8, jsonOption);
        Assert.That(jsonOption, Is.EqualTo(client.SerializerOptions));
        Assert.That(Encoding.UTF8, Is.EqualTo(client.Encoding));
        Assert.That(baseUrl, Is.EqualTo(client._client!.BaseAddress!.AbsoluteUri));
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
        _light.Encoding = Encoding.Unicode;
        Assert.That(_clientObj.Encoding, Is.EqualTo(Encoding.Unicode));
    }

    [Test]
    public void SetMediaType_Should_Set_Media_Type()
    {
        var media = "text";
        _light.MediaType = media;
        Assert.That(_clientObj.MediaType, Is.EqualTo(media));
    }

    [Test]
    public void SetSerializerOptions_Should_Set_Serialization()
    {
        var serializer = new JsonSerializerOptions();
        _light.SerializerOptions = serializer;
        Assert.That(JsonSerializer.Serialize(_clientObj.SerializerOptions),
            Is.EqualTo(JsonSerializer.Serialize(serializer)));
    }

    #region POST

    [Test]
    public async Task PostAsync_Should_Send_And_Receive_Body()
    {
        var game = new Game
        {
            Id = 8888,
            Title = "game return"
        };

        var (response, code) = await _light.PostAsync<Game, Game>(API_URL + "/return-body", game);

        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response!.Id, Is.EqualTo(game.Id));
            Assert.That(response.Title, Is.EqualTo(game.Title));
        });
    }

    [Test]
    public async Task PostAsync_Should_Send_And_Receive_Body_By_Uri()
    {
        var game = new Game
        {
            Id = 8888,
            Title = "game return"
        };

        var (response, code) = await _light.PostAsync<Game, Game>(new Uri(API_URL + "/return-body"), game);

        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response!.Id, Is.EqualTo(game.Id));
            Assert.That(response.Title, Is.EqualTo(game.Title));
        });
    }

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
    public async Task DeleteAsync_Should_Send_And_Receive_Body()
    {
        var game = new Game
        {
            Id = 8888,
            Title = "game return"
        };

        var (response, code) = await _light.DeleteAsync<Game, Game>(API_URL + "/return-body", game);

        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response!.Id, Is.EqualTo(game.Id));
            Assert.That(response.Title, Is.EqualTo(game.Title));
        });
    }

    [Test]
    public async Task DeleteAsync_Should_Send_And_Receive_Body_By_Uri()
    {
        var game = new Game
        {
            Id = 8888,
            Title = "game return"
        };

        var (response, code) = await _light.DeleteAsync<Game, Game>(new Uri(API_URL + "/return-body"), game);

        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response!.Id, Is.EqualTo(game.Id));
            Assert.That(response.Title, Is.EqualTo(game.Title));
        });
    }

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
    public async Task PutAsync_Should_Send_And_Receive_Body()
    {
        var game = new Game
        {
            Id = 8888,
            Title = "game return"
        };

        var (response, code) = await _light.PutAsync<Game, Game>(API_URL + "/return-body", game);

        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response!.Id, Is.EqualTo(game.Id));
            Assert.That(response.Title, Is.EqualTo(game.Title));
        });
    }

    [Test]
    public async Task PutAsync_Should_Send_And_Receive_Body_By_Uri()
    {
        var game = new Game
        {
            Id = 8888,
            Title = "game return"
        };

        var (response, code) = await _light.PutAsync<Game, Game>(new Uri(API_URL + "/return-body"), game);

        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response!.Id, Is.EqualTo(game.Id));
            Assert.That(response.Title, Is.EqualTo(game.Title));
        });
    }

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
    public async Task PatchAsync_Should_Send_And_Receive_Body()
    {
        var game = new Game
        {
            Id = 8888,
            Title = "game return"
        };

        var (response, code) = await _light.PatchAsync<Game, Game>(API_URL + "/return-body", game);

        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response!.Id, Is.EqualTo(game.Id));
            Assert.That(response.Title, Is.EqualTo(game.Title));
        });
    }

    [Test]
    public async Task PatchAsync_Should_Send_And_Receive_Body_By_Uri()
    {
        var game = new Game
        {
            Id = 8888,
            Title = "game return"
        };

        var (response, code) = await _light.PatchAsync<Game, Game>(new Uri(API_URL + "/return-body"), game);

        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response!.Id, Is.EqualTo(game.Id));
            Assert.That(response.Title, Is.EqualTo(game.Title));
        });
    }

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
        var (response, code) = await _light.PatchAsync(new Uri(API_URL + "/1"), game);
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
    public async Task GetAsync_Should_Send_And_Receive_Body()
    {
        var game = new Game
        {
            Id = 8888,
            Title = "game return"
        };

        var (response, code) = await _light.GetAsync<Game, Game>(API_URL + "/return-body", game);

        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response!.Id, Is.EqualTo(game.Id));
            Assert.That(response.Title, Is.EqualTo(game.Title));
        });
    }

    [Test]
    public async Task GetAsync_Should_Send_And_Receive_Body_By_Uri()
    {
        var game = new Game
        {
            Id = 8888,
            Title = "game return"
        };

        var (response, code) = await _light.GetAsync<Game, Game>(new Uri(API_URL + "/return-body"), game);

        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response!.Id, Is.EqualTo(game.Id));
            Assert.That(response.Title, Is.EqualTo(game.Title));
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
    public async Task HeadAsync_Should_Send_And_Receive_Body()
    {
        var game = new Game
        {
            Id = 8888,
            Title = "game return"
        };

        var (response, code) = await _light.HeadAsync<Game, Game>(API_URL + "/return-body", game);

        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response!.Id, Is.EqualTo(game.Id));
            Assert.That(response.Title, Is.EqualTo(game.Title));
        });
    }

    [Test]
    public async Task HeadAsync_Should_Send_And_Receive_Body_By_Uri()
    {
        var game = new Game
        {
            Id = 8888,
            Title = "game return"
        };

        var (response, code) = await _light.HeadAsync<Game, Game>(new Uri(API_URL + "/return-body"), game);

        Assert.Multiple(() =>
        {
            Assert.That(code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response!.Id, Is.EqualTo(game.Id));
            Assert.That(response.Title, Is.EqualTo(game.Title));
        });
    }

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

    [Test]
    [TestCase(Method.GET)]
    [TestCase(Method.DELETE)]
    [TestCase(Method.OPTIONS)]
    [TestCase(Method.HEAD)]
    [TestCase(Method.PUT)]
    [TestCase(Method.POST)]
    public async Task SendAsync_Should_Make_Request(Method httpMethod)
    {
        var (_, statusCode) = await _light.SendAsync(new HttpRequest(API_URL, httpMethod));
        Assert.That(statusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    #endregion

    [Test]
    public void Should_TimeoutProp_Set()
    {
        var span = TimeSpan.FromSeconds(1);
        _light.Timeout = span;
        Assert.That(_light.Timeout, Is.EqualTo(span));
    }

    [Test]
    public void Should_MaxResponseContentBufferSize_Set()
    {
        _light.MaxResponseContentBufferSize = 1;
        Assert.That(_light.MaxResponseContentBufferSize, Is.EqualTo(1));
    }

    [Test]
    public void Should_Set_Default_Header()
    {
        _light.AddDefaultHeader("test", "val");
        var keyValue = _clientObj._client.DefaultRequestHeaders.FirstOrDefault();
        Assert.That(keyValue.Key, Is.EqualTo("test"));
        Assert.That(keyValue.Value.ToList()[0], Is.EqualTo("val"));
    }
}
