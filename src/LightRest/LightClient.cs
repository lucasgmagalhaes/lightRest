using System.Net;
using System.Text;
using System.Text.Json;

namespace LightRest;

public sealed class LightClient : ILightClient
{
    #region PROPERTIES

    internal readonly HttpClient _client;
    internal string? _mediaType;
    internal Encoding? _encoding;
    internal bool _ensure;
    internal JsonSerializerOptions? _serializerOptions;

    public TimeSpan Timeout { get => _client.Timeout; set => _client.Timeout = value; }

    public long MaxResponseContentBufferSize { get => _client.MaxResponseContentBufferSize; set => _client.MaxResponseContentBufferSize = value; }

    #endregion

    #region CONSTRUCTORS
    public LightClient()
    {
        _client ??= new();
    }

    public LightClient(in Encoding? encoding, in JsonSerializerOptions? jsonSerializerOptions) : this()
    {
        _client ??= new();
        _serializerOptions = jsonSerializerOptions;
        _encoding = encoding;
    }

    public LightClient(in HttpClient client,
        in Encoding? encoding = null,
        in JsonSerializerOptions? jsonSerializerOptions = null) : this(encoding, jsonSerializerOptions)
    {
        _client = client;
    }

    public LightClient(in string baseUrl,
        in Encoding? encoding = null,
        in JsonSerializerOptions? jsonSerializerOptions = null) : this(encoding, jsonSerializerOptions)
    {
        _client ??= new();
        _client.BaseAddress = new Uri(baseUrl);
    }

    #endregion

    public ILightClient SetBaseUrl(in string url)
    {
        _client.BaseAddress = string.IsNullOrEmpty(url) ? null : new Uri(url);
        return this;
    }

    public ILightClient SetEnsureSuccess(in bool ensure)
    {
        _ensure = ensure;
        return this;
    }

    public ILightClient SetMediaType(in string? media)
    {
        _mediaType = media;
        return this;
    }

    public ILightClient SetEncoding(in Encoding? encoding)
    {
        _encoding = encoding;
        return this;
    }

    public ILightClient SetSerializerOptions(in JsonSerializerOptions options)
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

    public Task<(string?, HttpStatusCode)> GetAsync(in Uri url,
                                                in object? body = default,
                                                CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Get, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse, TRequest>(in string url,
                                                in TRequest? body = default,
                                                CancellationToken cancellationToken = default)
         where TResponse : class
         where TRequest : class
    {
        return SendAsync<TResponse, TRequest>(url, HttpMethod.Get, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse, TRequest>(in Uri url,
                                            in TRequest? body = default,
                                            CancellationToken cancellationToken = default)
     where TResponse : class
     where TRequest : class
    {
        return SendAsync<TResponse, TRequest>(url, HttpMethod.Get, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse>(in string url,
                                                                  in object? body = default,
                                                                  CancellationToken cancellationToken = default)
         where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Get, body, cancellationToken);
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

    public Task<(string?, HttpStatusCode)> PostAsync(in Uri url,
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

    public Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse>(in Uri url,
                                                                   in object? body = default,
                                                                   CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Post, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse, TRequest>(in string url,
                                                               in TRequest? body = default,
                                                               CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class
    {
        return SendAsync<TResponse, TRequest>(url, HttpMethod.Post, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse, TRequest>(in Uri url,
                                                                   in TRequest? body = default,
                                                                   CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        return SendAsync<TResponse, TRequest>(url, HttpMethod.Post, body, cancellationToken);
    }

    #endregion

    #region DELETE

    public Task<(string?, HttpStatusCode)> DeleteAsync(in string url, in object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> DeleteAsync(in Uri url, in object? body = default, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Delete, body, cancellationToken);
    }


    public Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default)
    where TResponse : class
    where TRequest : class
    {
        return SendAsync<TResponse, TRequest>(url, HttpMethod.Delete, body, cancellationToken);
    }


    public Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        return SendAsync<TResponse, TRequest>(url, HttpMethod.Delete, body, cancellationToken);
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

    public Task<(string?, HttpStatusCode)> PatchAsync(in Uri url,
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

    public Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse>(in Uri url,
                                                                    in object? body = default,
                                                                    CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse, TRequest>(in string url,
                                                                in TRequest? body = default,
                                                                CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class
    {
        return SendAsync<TResponse, TRequest>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse, TRequest>(in Uri url,
                                                                    in TRequest? body = default,
                                                                    CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class
    {
        return SendAsync<TResponse, TRequest>(url, HttpMethod.Patch, body, cancellationToken);
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

    public Task<(string?, HttpStatusCode)> PutAsync(in Uri url,
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

    public Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse>(in Uri url,
                                                                  in object? body = default,
                                                                  CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Put, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse, TRequest>(in string url,
                                                              in TRequest? body = default,
                                                              CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Put, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse, TRequest>(in Uri url,
                                                                  in TRequest? body = default,
                                                                  CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
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


    public Task<(string?, HttpStatusCode)> HeadAsync(in Uri url,
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

    public Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse>(in Uri url,
                                                                   in object? body = default,
                                                                   CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(url, HttpMethod.Head, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse, TRequest>(in string url,
                                                               in TRequest? body = default,
                                                               CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        return SendAsync<TResponse, TRequest>(url, HttpMethod.Head, body, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse, TRequest>(in Uri url,
                                                                   in TRequest? body = default,
                                                                   CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class
    {
        return SendAsync<TResponse, TRequest>(url, HttpMethod.Head, body, cancellationToken);
    }

    #endregion

    #region SEND

    public Task<(string?, HttpStatusCode)> SendAsync(in HttpRequest request, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request._httpRequest, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> SendAsync(in HttpRequestMessage request,
                                                 CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request, cancellationToken);
    }

    public Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(in HttpRequest request, CancellationToken cancellationToken = default) where TResponse : class
    {
        return SendAsync<TResponse>(request._httpRequest, cancellationToken);
    }


    public async Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(HttpRequestMessage request,
                                                                         CancellationToken cancellationToken = default) where TResponse : class
    {
        using var response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
        if (_ensure) response.EnsureSuccessStatusCode();
        return (await ReadContentAsync<TResponse>(response, cancellationToken).ConfigureAwait(false), response.StatusCode);
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

    public void CancelPendingRequests()
    {
        _client.CancelPendingRequests();
    }

    private Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse, TRequest>(in string url,
                                                                    HttpMethod method,
                                                                    TRequest? body = default,
                                                                    CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        var httpRequest = BuildHttpRequest(url, method, body);
        return SendAsync<TResponse>(httpRequest, cancellationToken);
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

    private Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse, TRequest>(in Uri url,
                                                                    HttpMethod method,
                                                                    TRequest? body = default,
                                                                    CancellationToken cancellationToken = default)
        where TResponse : class
    {
        var httpRequest = BuildHttpRequest(url, method, body);
        return SendAsync<TResponse>(httpRequest, cancellationToken);
    }

    private HttpRequestMessage BuildHttpRequest<T>(in Uri url, HttpMethod method, T? body = default)
    {
        var httpRequest = CreateHttpRequest(method, body);
        httpRequest.RequestUri = url;
        return httpRequest;
    }

    private HttpRequestMessage BuildHttpRequest<T>(in string url, HttpMethod method, T? body = default)
    {
        var httpRequest = CreateHttpRequest(method, body);
        httpRequest.RequestUri = GetUri(url);
        return httpRequest;
    }

    private HttpRequestMessage CreateHttpRequest<T>(in HttpMethod method, T? body = default)
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

        if (response.Content is null)
        {
            return default;
        }

        if (typeT == typeof(string))
        {
            return await ReadAsStringByFrameWorkVersionAsync(response.Content, cancellationToken)
                    .ConfigureAwait(false) as TResponse;
        }

        if (typeT == typeof(Stream))
        {
            return await ReadAsStreamAsyncByFrameWorkVersionAsync(response.Content, cancellationToken).ConfigureAwait(false) as TResponse;
        }

        if (typeT == typeof(byte[]))
        {
            return await ReadAsByteArrayAsyncByFrameWorkVersionAsync(response.Content, cancellationToken)
                .ConfigureAwait(false) as TResponse;
        }

        using var contentStream = await ReadAsStreamAsyncByFrameWorkVersionAsync(response.Content, cancellationToken)
            .ConfigureAwait(false);

        if (contentStream is null) return default;

        try
        {
            return await JsonSerializer.DeserializeAsync<TResponse>(contentStream, _serializerOptions, cancellationToken).ConfigureAwait(false);
        }
        catch (JsonException ex)
        {
            var stringResponse = await ReadAsStringByFrameWorkVersionAsync(response.Content, cancellationToken).ConfigureAwait(false);
            throw new SerializationException(stringResponse, "Error when attempting to serialize response. See exception details", ex);
        }
    }

    private string Serialize<T>(in T val)
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

#pragma warning disable S1172 // Unused method parameters should be removed
    private static Task<Stream> ReadAsStreamAsyncByFrameWorkVersionAsync(in HttpContent content, CancellationToken cancellationToken)
#pragma warning restore S1172 // Unused method parameters should be removed
    {
#if NETSTANDARD2_0
        return content.ReadAsStreamAsync();
#else
        return content.ReadAsStreamAsync(cancellationToken);
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