using System.Net;
using System.Text;
using System.Text.Json;

namespace LightRest;

public sealed class LightClient : IDisposable
{
    internal readonly HttpClient _client;
    internal string? _mediaType;
    internal Encoding? _encoding;
    internal bool _ensure;
    internal JsonSerializerOptions? _serializerOptions;

    public LightClient()
    {
        _client ??= new();
    }

    public LightClient(Encoding? encoding, JsonSerializerOptions? jsonSerializerOptions) : this()
    {
        _client ??= new();
        _serializerOptions = jsonSerializerOptions;
        _encoding = encoding;
    }

    public LightClient(in HttpClient client, Encoding? encoding = null, JsonSerializerOptions? jsonSerializerOptions = null) : this(encoding, jsonSerializerOptions)
    {
        _client = client;
    }

    public LightClient(in string baseUrl, Encoding? encoding = null, JsonSerializerOptions? jsonSerializerOptions = null) : this(encoding, jsonSerializerOptions)
    {
        _client ??= new();
        _client.BaseAddress = new Uri(baseUrl);
    }

    public LightClient SetBaseUrl(in string url)
    {
        _client.BaseAddress = string.IsNullOrEmpty(url) ? null : new Uri(url);
        return this;
    }

    public LightClient SetEnsureSuccess(in bool ensure)
    {
        _ensure = ensure;
        return this;
    }

    public LightClient SetMediaType(in string? media)
    {
        _mediaType = media;
        return this;
    }

    public LightClient SetEncoding(in Encoding? encoding)
    {
        _encoding = encoding;
        return this;
    }

    public LightClient SetSerializerOptions(in JsonSerializerOptions options)
    {
        _serializerOptions = options;
        return this;
    }

    #region HEADER

    public LightClient AddDefaultHeader(in string name, string value)
    {
        _client.DefaultRequestHeaders.Add(name, value);
        return this;
    }

    public LightClient AddDefaultHeader(in string name, IEnumerable<string> values)
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

    public Task<(string?, HttpStatusCode)> GetAsync(in string url,
                                                    in object? body = default,
                                                    CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Get, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse>(in string url,
                                                                  in object? body = default,
                                                                  CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Get, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> GetAsync(in Uri url,
                                                    in object? body = default,
                                                    CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Get, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse>(in Uri url,
                                                                  in object? body = default,
                                                                  CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Get, body, cancellationToken);
    }

    #endregion

    #region POST

    public Task<(string?, HttpStatusCode)> PostAsync(in string url,
                                                     in object? body = default,
                                                     CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Post, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse>(in string url,
                                                                   in object? body = default,
                                                                   CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Post, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> PostAsync(in Uri url,
                                                     in object? body = default,
                                                     CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Post, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse>(in Uri url,
                                                                   in object? body = default,
                                                                   CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Post, body, cancellationToken);
    }

    #endregion

    #region DELETE

    public Task<(string?, HttpStatusCode)> DeleteAsync(in string url,
                                                       in object? body = default,
                                                       CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse>(in string url,
                                                                     in object? body = default,
                                                                     CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> DeleteAsync(in Uri url, in object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse>(in Uri url,
                                                                     in object? body = default,
                                                                     CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Delete, body, cancellationToken);
    }

    #endregion

    #region PATCH

#if !NETSTANDARD2_0

    public Task<(string?, HttpStatusCode)> PatchAsync(in string url,
                                                      in object? body = default,
                                                      CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse>(in string url,
                                                                    in object? body = default,
                                                                    CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> PatchAsync(in Uri url,
                                                      in object? body = default,
                                                      CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse>(in Uri url,
                                                                    in object? body = default,
                                                                    CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Patch, body, cancellationToken);
    }

#endif
    #endregion

    #region PUT

    public Task<(string?, HttpStatusCode)> PutAsync(in string url,
                                                    in object? body = default,
                                                    CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Put, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse>(in string url,
                                                                  in object? body = default,
                                                                  CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Put, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> PutAsync(in Uri url,
                                                    in object? body = default,
                                                    CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Put, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse>(in Uri url,
                                                                  in object? body = default,
                                                                  CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Put, body, cancellationToken);
    }

    #endregion

    #region HEAD

    public Task<(string?, HttpStatusCode)> HeadAsync(in string url,
                                                     in object? body = default,
                                                     CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Head, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse>(in string url,
                                                                   in object? body = default,
                                                                   CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Head, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> HeadAsync(in Uri url,
                                                     in object? body = default,
                                                     CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Head, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse>(in Uri url,
                                                                   in object? body = default,
                                                                   CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Head, body, cancellationToken);
    }

    #endregion

    #region SEND

    public Task<(string?, HttpStatusCode)> SendAsync(in HttpRequest request, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request._httpRequest, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(in HttpRequest request, CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(request._httpRequest, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> SendAsync(in HttpRequestMessage request,
                                                     CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request, cancellationToken);
    }

    public async Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(HttpRequestMessage request,
                                                                         CancellationToken cancellationToken = default) where TResponse : class
    {
        var response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
        if (_ensure) response.EnsureSuccessStatusCode();
        return (await ReadContentAsync<TResponse>(response, cancellationToken).ConfigureAwait(false), response.StatusCode);
    }

    public Task<(string?, HttpStatusCode)> SendAsync(in string url, HttpMethod method, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, method, null, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(in string url,
                                                                   HttpMethod method,
                                                                   CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, method, null, cancellationToken);
    }

    #endregion

    public Task<string> GetStringAsync(in string url)
    {
        return _client.GetStringAsync(url);
    }

    public Task<string> GetStringAsync(in Uri url)
    {
        return _client.GetStringAsync(url);
    }

    public Task<Stream> GetStreamAsync(in Uri url)
    {
        return _client.GetStreamAsync(url);
    }

    public Task<Stream> GetStreamAsync(in string url)
    {
        return _client.GetStreamAsync(url);
    }

    public Task<byte[]> GetByteArrayAsync(in string url)
    {
        return _client.GetByteArrayAsync(url);
    }

    public Task<byte[]> GetByteArrayAsync(in Uri url)
    {
        return _client.GetByteArrayAsync(url);
    }

    private Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(in string url,
                                                                    HttpMethod method,
                                                                    object? body = default,
                                                                    CancellationToken cancellationToken = default)
        where TResponse : class
    {
        var httpRequest = BuildHttpRequest(url, method, body);
        return SendAsync<TResponse>(httpRequest, cancellationToken);
    }

    private Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(in Uri url,
                                                                    HttpMethod method,
                                                                    object? body = default,
                                                                    CancellationToken cancellationToken = default)
        where TResponse : class
    {
        var httpRequest = BuildHttpRequest(url, method, body);
        return SendAsync<TResponse>(httpRequest, cancellationToken);
    }

    private HttpRequestMessage BuildHttpRequest(in Uri url, HttpMethod method, object? body = default)
    {
        var httpRequest = CreateHttpRequest(method, body);
        httpRequest.RequestUri = url;
        return httpRequest;
    }

    private HttpRequestMessage BuildHttpRequest(in string url, HttpMethod method, object? body = default)
    {
        var httpRequest = CreateHttpRequest(method, body);
        httpRequest.RequestUri = GetUri(url);
        return httpRequest;
    }

    private HttpRequestMessage CreateHttpRequest(in HttpMethod method, object? body = default)
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

    private static Uri? GetUri(in string url)
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

    private string Serialize(in object val)
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
    private static Task<string> ReadAsStringByFrameWorkVersionAsync(in HttpContent content, CancellationToken cancellationToken)
#pragma warning restore S1172 // Unused method parameters should be removed
    {
#if NETSTANDARD2_0
        return content.ReadAsStringAsync();
#else
        return content.ReadAsStringAsync(cancellationToken);
#endif
    }

#pragma warning disable S1172 // Unused method parameters should be removed
    private static Task<byte[]> ReadAsByteArrayAsyncByFrameWorkVersionAsync(in HttpContent content, CancellationToken cancellationToken)
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

    private void Dispose(in bool disposing)
    {
        if (disposing)
        {
            _client.Dispose();
        }
    }
}