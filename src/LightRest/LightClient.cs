using System.Net;
using System.Text;
using System.Text.Json;

namespace LightRest;

public class LightClient : IDisposable
{
    protected internal readonly HttpClient _client;
    protected internal string? _mediaType;
    protected internal Encoding? _encoding;
    protected internal bool _ensure;
    protected internal JsonSerializerOptions? _serializerOptions;

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
        _client.BaseAddress = string.IsNullOrEmpty(url) ? null : new Uri(url);
        return this;
    }

    public LightClient SetEnsureSuccess(bool ensure)
    {
        _ensure = ensure;
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

    public Task<(string?, HttpStatusCode)> GetAsync(string url, object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Get, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse>(string url, object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Get, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> GetAsync(Uri url, object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Get, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse>(Uri url, object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Get, body, cancellationToken);
    }

    #endregion

    #region POST

    public Task<(string?, HttpStatusCode)> PostAsync(string url, object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Post, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse>(string url, object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Post, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> PostAsync(Uri url, object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Post, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse>(Uri url, object? body = default, CancellationToken cancellationToken = default) 
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Post, body, cancellationToken);
    }

    #endregion

    #region DELETE

    public Task<(string?, HttpStatusCode)> DeleteAsync(string url, object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse>(string url, object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Delete, body, cancellationToken);
    }
    
    public Task<(string?, HttpStatusCode)> DeleteAsync(Uri url, object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse>(Uri url, object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Delete, body, cancellationToken);
    }

    #endregion

    #region PATCH

#if !NETSTANDARD2_0

    public Task<(string?, HttpStatusCode)> PatchAsync(string url, object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse>(string url, object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Patch, body, cancellationToken);
    }
    
    public Task<(string?, HttpStatusCode)> PatchAsync(Uri url, object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse>(Uri url, object? body = default, CancellationToken cancellationToken = default) 
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Patch, body, cancellationToken);
    }

#endif
    #endregion

    #region PUT

    public Task<(string?, HttpStatusCode)> PutAsync(string url, object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Put, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse>(string url, object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Put, body, cancellationToken);
    }
    
    public Task<(string?, HttpStatusCode)> PutAsync(Uri url, object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Put, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse>(Uri url, object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Put, body, cancellationToken);
    }

    #endregion

    #region HEAD

    public Task<(string?, HttpStatusCode)> HeadAsync(string url, object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Head, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse>(string url, object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Head, body, cancellationToken);
    }
    
    public Task<(string?, HttpStatusCode)> HeadAsync(Uri url, object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Head, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse>(Uri url, object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Head, body, cancellationToken);
    }

    #endregion

    #region SEND

    public Task<(string?, HttpStatusCode)> SendAsync(HttpRequest request, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request._httpRequest, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(HttpRequest request, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return SendAsync<TResponse>(request._httpRequest, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request, cancellationToken);
    }

    public async Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(HttpRequestMessage request, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        var response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
        if (_ensure) response.EnsureSuccessStatusCode();
        return (await ReadContentAsync<TResponse>(response, cancellationToken).ConfigureAwait(false), response.StatusCode);
    }

    public Task<(string?, HttpStatusCode)> SendAsync(string url, HttpMethod method, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, method, null, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(string url, HttpMethod method, CancellationToken cancellationToken = default) 
        where TResponse : class
    {
        return SendAsync<TResponse>(url, method, null, cancellationToken);
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

    private Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(string url, HttpMethod method, object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        var httpRequest = BuildHttpRequest(url, method, body);
        return SendAsync<TResponse>(httpRequest, cancellationToken);
    }

    private Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(Uri url, HttpMethod method, object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        var httpRequest = BuildHttpRequest(url, method, body);
        return SendAsync<TResponse>(httpRequest, cancellationToken);
    }

    private HttpRequestMessage BuildHttpRequest(Uri url, HttpMethod method, object? body = default)
    {
        var httpRequest = CreateHttpRequest(method, body);
        httpRequest.RequestUri = url;
        return httpRequest;
    }

    private HttpRequestMessage BuildHttpRequest(string url, HttpMethod method, object? body = default)
    {
        var httpRequest = CreateHttpRequest(method, body);
        httpRequest.RequestUri = GetUri(url);
        return httpRequest;
    }

    private HttpRequestMessage CreateHttpRequest(HttpMethod method, object? body = default)
    {
        var httpRequest = new HttpRequestMessage
        {
            Method = method,
        };

        if (body is not null)
        {
            httpRequest.Content = new StringContent(Serialize(body), _encoding, _mediaType);
        }
        return httpRequest;
    }

    private static Uri? GetUri(string url)
    {
        return string.IsNullOrEmpty(url) ? null : new Uri(url);
    }

    private async Task<TResponse?> ReadContentAsync<TResponse>(HttpResponseMessage response, CancellationToken cancellationToken = default) where TResponse : class
    {
        var typeT = typeof(TResponse);

        if (typeT == typeof(string))
        {
            return (await ReadAsStringByFrameWorkVersionAsync(response.Content, cancellationToken)
                    .ConfigureAwait(false)) as TResponse;
        }

        if (typeT == typeof(byte[]))
        {
            return (await ReadAsByteArrayAsyncByFrameWorkVersionAsync(response.Content, cancellationToken)
                .ConfigureAwait(false)) as TResponse;
        }

        var byteVal = await ReadAsByteArrayAsyncByFrameWorkVersionAsync(response.Content, cancellationToken)
            .ConfigureAwait(false);

        if (byteVal is null) return default;

        try
        {
            return JsonSerializer.Deserialize<TResponse>(byteVal, _serializerOptions);
        }
        catch (Exception ex)
        {
            throw new SerializationException(
                _encoding?.GetString(byteVal) ?? Encoding.UTF8.GetString(byteVal), 
                "Error when attempting to serialize response. See exception details", ex);
        }
    }

    private string Serialize(object val)
    {
        if (val is string valString)
        {
            if (string.IsNullOrEmpty(valString))
            {
                return string.Empty;
            }
            else
            {
                return valString;
            }
        }
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