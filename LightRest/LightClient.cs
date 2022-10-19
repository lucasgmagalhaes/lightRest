using System.Net;
using System.Text;
using System.Text.Json;

namespace LightRest;

public class LightClient : IDisposable
{
    private readonly HttpClient _client;
    private string? _mediaType;
    private Encoding? _encoding;
    private JsonSerializerOptions? _serializerOptions;

    public LightClient()
    {
        _client ??= new();
    }

    public LightClient(HttpClient client) : this()
    {
        _client = client;
    }

    public LightClient(string baseUrl) : this()
    {
        _client ??= new();
        _client.BaseAddress = new Uri(baseUrl);
    }

    public LightClient SetBaseUrl(string url)
    {
        _client.BaseAddress = new Uri(url);
        return this;
    }

    public LightClient SetMediaType(string? media)
    {
        _mediaType = media;
        return this;
    }

    public LightClient SetEncoding(Encoding? encoding)
    {
        _encoding = encoding;
        return this;
    }

    public LightClient SetSerializerOptions(JsonSerializerOptions options)
    {
        _serializerOptions = options;
        return this;
    }

    #region HEADER

    public LightClient AddDefaultHeader(string name, string value)
    {
        _client.DefaultRequestHeaders.Add(name, value);
        return this;
    }

    public LightClient AddDefaultHeader(string name, IEnumerable<string> values)
    {
        _client.DefaultRequestHeaders.Add(name, values);
        return this;
    }

    public LightClient ClearDefaultHeaders()
    {
        _client.DefaultRequestHeaders.Clear();
        return this;
    }

    #endregion

    #region GET

    public Task<(string?, HttpStatusCode)> GetAsync(string url, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Get, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> GetAsync<T>(string url, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Get, cancellationToken);
    }

    #endregion

    #region POST

    public Task<(string?, HttpStatusCode)> PostAsync(string url, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Post, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> PostAsync<T>(string url, T body, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<string>(url, HttpMethod.Post, Serialize(body), cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> PostAsync<T>(string url, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Post, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> PostAsync(string url, string body, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Post, body, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> PostAsync<T>(string url, string body, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Post, body, cancellationToken);
    }

    #endregion

    #region DELETE

    public Task<(string?, HttpStatusCode)> DeleteAsync(string url, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Delete, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> DeleteAsync(string url, string body, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> DeleteAsync<T>(string url, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Delete, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> DeleteAsync<T>(string url, string body, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Delete, body, cancellationToken);
    }

    #endregion

    #region PATCH

#if !NETSTANDARD2_0

    public Task<(string?, HttpStatusCode)> PatchAsync(string url, string body, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> PatchAsync<T>(string url, T body, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Patch, Serialize<T>(body), cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> PatchAsync<T>(string url, string body, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Patch, body, cancellationToken);
    }

#endif
    #endregion

    #region PUT

    public Task<(string?, HttpStatusCode)> PutAsync(string url, string body, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Put, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> PutAsync<T>(string url, T body, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<string>(url, HttpMethod.Put, Serialize(body), cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> PutAsync(string url, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Put, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> PutAsync<T>(string url, string body, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Put, body, cancellationToken);
    }

    #endregion

    #region HEAD

    public Task<(string?, HttpStatusCode)> HeadAsync(string url, CancellationToken cancellationToken = default)
    {
        return HeadAsync<string>(url, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> HeadAsync<T>(string url, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Head, cancellationToken);
    }

    #endregion

    #region SEND

    public Task<(string?, HttpStatusCode)> SendAsync(HttpRequest request, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request._httpRequest, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> SendAsync<T>(HttpRequest request, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(request._httpRequest, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request, cancellationToken);
    }

    public async Task<(T?, HttpStatusCode)> SendAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken = default) where T : class
    {
        var response = await _client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return (await ReadContentAsync<T>(response, cancellationToken), response.StatusCode);
    }

    public Task<(string?, HttpStatusCode)> SendAsync(string url, HttpMethod method, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, method, null, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> SendAsync<T>(string url, HttpMethod method, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, method, null, cancellationToken);
    }

    #endregion

    public Task<string> GetStringAsync(string url)
    {
        return _client.GetStringAsync(url);
    }

    public Task<string> GetStringAsync(Uri url)
    {
        return _client.GetStringAsync(url);
    }

    public Task<Stream> GetStreamAsync(Uri url)
    {
        return _client.GetStreamAsync(url);
    }

    public Task<Stream> GetStreamAsync(string url)
    {
        return _client.GetStreamAsync(url);
    }

    public Task<byte[]> GetByteArrayAsync(string url)
    {
        return _client.GetByteArrayAsync(url);
    }

    public Task<byte[]> GetByteArrayAsync(Uri url)
    {
        return _client.GetByteArrayAsync(url);
    }

    private Task<(T?, HttpStatusCode)> SendAsync<T>(string url, HttpMethod method, string? body = null, CancellationToken cancellationToken = default) where T : class
    {
        var httpRequest = new HttpRequestMessage
        {
            Method = method,
            RequestUri = string.IsNullOrEmpty(url) ? null : new Uri(url),
        };

        if (!string.IsNullOrEmpty(body))
        {
            httpRequest.Content = new StringContent(body, _encoding, _mediaType);
        }
        return SendAsync<T>(httpRequest, cancellationToken);
    }

    private async Task<T?> ReadContentAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken = default) where T : class
    {
        if (typeof(T) == typeof(string))
        {
            return (await ReadAsStringByFrameWorkVersionAsync(response.Content, cancellationToken)) as T;
        }

        if (typeof(T) == typeof(byte[]))
        {
            return (await ReadAsByteArrayAsyncByFrameWorkVersionAsync(response.Content, cancellationToken)) as T;
        }

        var stringVal = await ReadAsStringByFrameWorkVersionAsync(response.Content, cancellationToken);
        if (stringVal is null) return default;

        try
        {
            return JsonSerializer.Deserialize<T>(stringVal, _serializerOptions);
        }
        catch (Exception ex)
        {
            throw new SerializationException(stringVal, "Error when attempting to serialize response. See exception details", ex);
        }
    }

    private string Serialize<T>(T val)
    {
        return JsonSerializer.Serialize(val, _serializerOptions);
    }

#pragma warning disable S1172 // Unused method parameters should be removed
    private static Task<string> ReadAsStringByFrameWorkVersionAsync(HttpContent content, CancellationToken cancellationToken)
#pragma warning restore S1172 // Unused method parameters should be removed
    {
#if NETSTANDARD2_0
        return content.ReadAsStringAsync();
#else
        return content.ReadAsStringAsync(cancellationToken);
#endif
    }

#pragma warning disable S1172 // Unused method parameters should be removed
    private static Task<byte[]> ReadAsByteArrayAsyncByFrameWorkVersionAsync(HttpContent content, CancellationToken cancellationToken)
#pragma warning restore S1172 // Unused method parameters should be removed
    {
#if NETSTANDARD2_0
        return content.ReadAsByteArrayAsync();
#else
        return content.ReadAsByteArrayAsync(cancellationToken);
#endif
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _client.Dispose();
        }
    }
}