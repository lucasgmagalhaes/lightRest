using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;
using System.Text.Json;

namespace LightRest;

public sealed class LightClient : ILightClient
{
    #region PROPERTIES

    public string? MediaType { get; set; }
    public Encoding? Encoding { get; set; }
    public bool EnsureSuccess { get; set; }
    public JsonSerializerOptions SerializerOptions { get; set; }
    public TimeSpan Timeout { get => _client.Timeout; set => _client.Timeout = value; }
    public long MaxResponseContentBufferSize { get => _client.MaxResponseContentBufferSize; set => _client.MaxResponseContentBufferSize = value; }

    internal readonly HttpClient _client;

    #endregion

    #region CONSTRUCTORS
    public LightClient()
    {
        // Inits JsonSerializerOptions so It can be cached
        SerializerOptions ??= new JsonSerializerOptions();
        _client ??= new();
    }

    public LightClient(in Encoding? encoding, in JsonSerializerOptions? jsonSerializerOptions) : this()
    {
        _client ??= new();

        if (jsonSerializerOptions is not null)
        {
            SerializerOptions = jsonSerializerOptions;
        }

        Encoding = encoding;
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

    public (string?, HttpStatusCode) Get(in string url,
                                                in object? body = default,
                                                CancellationToken cancellationToken = default)
    {
        return Send<string>(url, HttpMethod.Get, body, cancellationToken);
    }

    public (string?, HttpStatusCode) Get(in Uri url,
                                                in object? body = default,
                                                CancellationToken cancellationToken = default)
    {
        return Send<string>(url, HttpMethod.Get, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Get<TResponse, TRequest>(in string url,
                                                in TRequest? body = default,
                                                CancellationToken cancellationToken = default)
         where TResponse : class
         where TRequest : class
    {
        return Send<TResponse, TRequest>(url, HttpMethod.Get, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Get<TResponse, TRequest>(in Uri url,
                                            in TRequest? body = default,
                                            CancellationToken cancellationToken = default)
     where TResponse : class
     where TRequest : class
    {
        return Send<TResponse, TRequest>(url, HttpMethod.Get, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Get<TResponse>(in string url,
                                                                  in object? body = default,
                                                                  CancellationToken cancellationToken = default)
         where TResponse : class
    {
        return Send<TResponse>(url, HttpMethod.Get, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Get<TResponse>(in Uri url,
                                                                  in object? body = default,
                                                                  CancellationToken cancellationToken = default) where TResponse : class
    {
        return Send<TResponse>(url, HttpMethod.Get, body, cancellationToken);
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

    public (string?, HttpStatusCode) Post(in string url,
                                                 in object? body = default,
                                                 CancellationToken cancellationToken = default)
    {
        return Send<string>(url, HttpMethod.Post, body, cancellationToken);
    }

    public (string?, HttpStatusCode) Post(in Uri url,
                                                     in object? body = default,
                                                     CancellationToken cancellationToken = default)
    {
        return Send<string>(url, HttpMethod.Post, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Post<TResponse>(in string url,
                                                                   in object? body = default,
                                                                   CancellationToken cancellationToken = default) where TResponse : class
    {
        return Send<TResponse>(url, HttpMethod.Post, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Post<TResponse>(in Uri url,
                                                                   in object? body = default,
                                                                   CancellationToken cancellationToken = default) where TResponse : class
    {
        return Send<TResponse>(url, HttpMethod.Post, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Post<TResponse, TRequest>(in string url,
                                                               in TRequest? body = default,
                                                               CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        return Send<TResponse, TRequest>(url, HttpMethod.Post, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Post<TResponse, TRequest>(in Uri url,
                                                                   in TRequest? body = default,
                                                                   CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        return Send<TResponse, TRequest>(url, HttpMethod.Post, body, cancellationToken);
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


    public (string?, HttpStatusCode) Delete(in string url, in object? body = default, CancellationToken cancellationToken = default)
    {
        return Send<string>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public (string?, HttpStatusCode) Delete(in Uri url, in object? body = default, CancellationToken cancellationToken = default)
    {
        return Send<string>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Delete<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return Send<TResponse>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Delete<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class
    {
        return Send<TResponse>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Delete<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default)
    where TResponse : class
    where TRequest : class
    {
        return Send<TResponse, TRequest>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Delete<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        return Send<TResponse, TRequest>(url, HttpMethod.Delete, body, cancellationToken);
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

    public (string?, HttpStatusCode) Patch(in string url,
                                                    in object? body = default,
                                                    CancellationToken cancellationToken = default)
    {
        return Send<string>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public (string?, HttpStatusCode) Patch(in Uri url,
                                                  in object? body = default,
                                                  CancellationToken cancellationToken = default)
    {
        return Send<string>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Patch<TResponse>(in string url,
                                                                    in object? body = default,
                                                                    CancellationToken cancellationToken = default) where TResponse : class
    {
        return Send<TResponse>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Patch<TResponse>(in Uri url,
                                                                    in object? body = default,
                                                                    CancellationToken cancellationToken = default) where TResponse : class
    {
        return Send<TResponse>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Patch<TResponse, TRequest>(in string url,
                                                                in TRequest? body = default,
                                                                CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        return Send<TResponse, TRequest>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Patch<TResponse, TRequest>(in Uri url,
                                                                    in TRequest? body = default,
                                                                    CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        return Send<TResponse, TRequest>(url, HttpMethod.Patch, body, cancellationToken);
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

    public (string?, HttpStatusCode) Put(in string url,
                                                   in object? body = default,
                                                   CancellationToken cancellationToken = default)
    {
        return Send<string>(url, HttpMethod.Put, body, cancellationToken);
    }

    public (string?, HttpStatusCode) Put(in Uri url,
                                                in object? body = default,
                                                CancellationToken cancellationToken = default)
    {
        return Send<string>(url, HttpMethod.Put, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Put<TResponse>(in string url,
                                                                  in object? body = default,
                                                                  CancellationToken cancellationToken = default) where TResponse : class
    {
        return Send<TResponse>(url, HttpMethod.Put, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Put<TResponse>(in Uri url,
                                                                  in object? body = default,
                                                                  CancellationToken cancellationToken = default) where TResponse : class
    {
        return Send<TResponse>(url, HttpMethod.Put, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Put<TResponse, TRequest>(in string url,
                                                              in TRequest? body = default,
                                                              CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        return Send<TResponse>(url, HttpMethod.Put, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Put<TResponse, TRequest>(in Uri url,
                                                                  in TRequest? body = default,
                                                                  CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        return Send<TResponse>(url, HttpMethod.Put, body, cancellationToken);
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

    public (string?, HttpStatusCode) Head(in string url,
                                                    in object? body = default,
                                                    CancellationToken cancellationToken = default)
    {
        return Send<string>(url, HttpMethod.Head, body, cancellationToken);
    }


    public (string?, HttpStatusCode) Head(in Uri url,
                                                     in object? body = default,
                                                     CancellationToken cancellationToken = default)
    {
        return Send<string>(url, HttpMethod.Head, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Head<TResponse>(in string url,
                                                                   in object? body = default,
                                                                   CancellationToken cancellationToken = default) where TResponse : class
    {
        return Send<TResponse>(url, HttpMethod.Head, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Head<TResponse>(in Uri url,
                                                                   in object? body = default,
                                                                   CancellationToken cancellationToken = default) where TResponse : class
    {
        return Send<TResponse>(url, HttpMethod.Head, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Head<TResponse, TRequest>(in string url,
                                                               in TRequest? body = default,
                                                               CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        return Send<TResponse, TRequest>(url, HttpMethod.Head, body, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Head<TResponse, TRequest>(in Uri url,
                                                                   in TRequest? body = default,
                                                                   CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class
    {
        return Send<TResponse, TRequest>(url, HttpMethod.Head, body, cancellationToken);
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

    public (string?, HttpStatusCode) Send(in HttpRequest request, CancellationToken cancellationToken = default)
    {
        return Send<string>(request._httpRequest, cancellationToken);
    }

    public (TResponse?, HttpStatusCode) Send<TResponse>(in HttpRequest request, CancellationToken cancellationToken = default) where TResponse : class
    {
        return Send<TResponse>(request._httpRequest, cancellationToken);
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

    public string GetString(in string url)
    {
        return _client.GetStringAsync(url).GetAwaiter().GetResult();
    }

    public string GetString(in Uri url)
    {
        return _client.GetStringAsync(url).GetAwaiter().GetResult();
    }

    public Task<Stream> GetStreamAsync(in Uri url)
    {
        return _client.GetStreamAsync(url);
    }

    public Task<Stream> GetStreamAsync(in string url)
    {
        return _client.GetStreamAsync(url);
    }

    public Stream GetStream(in Uri url)
    {
        return _client.GetStreamAsync(url).GetAwaiter().GetResult();
    }

    public Stream GetStream(in string url)
    {
        return _client.GetStreamAsync(url).GetAwaiter().GetResult();
    }

    public Task<byte[]> GetByteArrayAsync(in string url)
    {
        return _client.GetByteArrayAsync(url);
    }

    public Task<byte[]> GetByteArrayAsync(in Uri url)
    {
        return _client.GetByteArrayAsync(url);
    }

    public byte[] GetByteArray(in string url)
    {
        return _client.GetByteArrayAsync(url).GetAwaiter().GetResult();
    }

    public byte[] GetByteArray(in Uri url)
    {
        return _client.GetByteArrayAsync(url).GetAwaiter().GetResult();
    }

    public void CancelPendingRequests()
    {
        _client.CancelPendingRequests();
    }

    private (TResponse?, HttpStatusCode) Send<TResponse>(in Uri url,
                                                            HttpMethod method,
                                                            object? body = default,
                                                            CancellationToken cancellationToken = default)
        where TResponse : class
    {
        var httpRequest = BuildHttpRequest(url, method, body);
        return Send<TResponse>(httpRequest, cancellationToken);
    }

    private (TResponse?, HttpStatusCode) Send<TResponse>(in string url,
                                                            HttpMethod method,
                                                            object? body = default,
                                                            CancellationToken cancellationToken = default)
        where TResponse : class
    {
        var httpRequest = BuildHttpRequest(url, method, body);
        return Send<TResponse>(httpRequest, cancellationToken);
    }

    private (TResponse?, HttpStatusCode) Send<TResponse, TRequest>(in Uri url,
                                                                HttpMethod method,
                                                                TRequest? body = default,
                                                                CancellationToken cancellationToken = default)
    where TResponse : class
    {
        var httpRequest = BuildHttpRequest(url, method, body);
        return Send<TResponse>(httpRequest, cancellationToken);
    }

    private (TResponse?, HttpStatusCode) Send<TResponse>(HttpRequestMessage request,
                                                             CancellationToken cancellationToken = default) where TResponse : class
    {
#if !NETSTANDARD2_0
        using var response = _client.Send(request, cancellationToken);
#else
        using var response = _client.SendAsync(request, cancellationToken).GetAwaiter().GetResult();
#endif
        if (EnsureSuccess) response.EnsureSuccessStatusCode();
        return (ReadContentAsync<TResponse>(response, cancellationToken).GetAwaiter().GetResult(), response.StatusCode);
    }

    private (TResponse?, HttpStatusCode) Send<TResponse, TRequest>(in string url,
                                                                HttpMethod method,
                                                                TRequest? body = default,
                                                                CancellationToken cancellationToken = default)
    where TResponse : class
    where TRequest : class
    {
        var httpRequest = BuildHttpRequest(url, method, body);
        return Send<TResponse>(httpRequest, cancellationToken);
    }

    private async Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken = default) where TResponse : class
    {
        using var response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
        if (EnsureSuccess) response.EnsureSuccessStatusCode();
        return (await ReadContentAsync<TResponse>(response, cancellationToken).ConfigureAwait(false), response.StatusCode);
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
#if !NETSTANDARD2_0
            Version = _client.DefaultRequestVersion,            
#endif
        };

        if (body is not null)
        {
            httpRequest.Content = new StringContent(JsonHelper.Serialize(body, SerializerOptions), Encoding, MediaType);
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
            return await HttpContentHelper.ReadAsStringAsync(response.Content, cancellationToken).ConfigureAwait(false) as TResponse;
        }

        if (typeT == typeof(Stream))
        {
            return await HttpContentHelper.ReadAsStreamAsync(response.Content, cancellationToken).ConfigureAwait(false) as TResponse;
        }

        if (typeT == typeof(byte[]))
        {
            return await HttpContentHelper.ReadAsByteArrayAsync(response.Content, cancellationToken).ConfigureAwait(false) as TResponse;
        }

        try
        {
            return await HttpContentHelper.ReadAsJsonAsync<TResponse>(response.Content, SerializerOptions, cancellationToken).ConfigureAwait(false);
        }
        catch (JsonException ex)
        {
            var stringResponse = await HttpContentHelper.ReadAsStringAsync(response.Content, cancellationToken).ConfigureAwait(false);
            throw new SerializationException(stringResponse, "Error when attempting to serialize response. See exception details", ex);
        }
    }

    [ExcludeFromCodeCoverage]
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    [ExcludeFromCodeCoverage]
    private void Dispose(in bool disposing)
    {
        if (disposing)
        {
            _client.Dispose();
        }
    }
}