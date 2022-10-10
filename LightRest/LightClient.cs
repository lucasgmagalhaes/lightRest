using System.Net;
using System.Text;
using System.Text.Json;

namespace LightRest;

public class LightClient : IDisposable
{
    private readonly HttpClient client = new();
    private string? _mediaType;
    private Encoding? _encoding;

    public LightClient()
    {
    }

    public LightClient(HttpClient client)
    {
        this.client = client;
    }

    public LightClient(string baseUrl)
    {
        client.BaseAddress = new Uri(baseUrl);
    }

    public void SetMediaType(string? media)
    {
        _mediaType = media;
    }

    public void SetEncoding(Encoding? encoding)
    {
        _encoding = encoding;
    }


    #region GET

    public Task<(string?, HttpStatusCode)> GetAsync(string url, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Get, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> GetAsync(HttpRequest request, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request.httpRequest, HttpMethod.Get, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> GetAsync<T>(string url, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Get, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> GetAsync<T>(HttpRequest request, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(request.httpRequest, HttpMethod.Get, cancellationToken);
    }

    #endregion

    #region POST

    public Task<(string?, HttpStatusCode)> PostAsync(string url, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Post, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> PostAsync<T>(string url, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Post, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> PostAsync(string url, string body, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Post, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> PostAsync(HttpRequest request, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request.httpRequest, HttpMethod.Post, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> PostAsync<T>(string url, string body, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Post, body, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> PostAsync<T>(HttpRequest request, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(request.httpRequest, HttpMethod.Post, cancellationToken);
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

    public Task<(string?, HttpStatusCode)> DeleteAsync(HttpRequest request, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request.httpRequest, HttpMethod.Delete, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> DeleteAsync<T>(string url, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Delete, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> DeleteAsync<T>(string url, string body, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Delete, body, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> DeleteAsync<T>(HttpRequest request, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(request.httpRequest, HttpMethod.Delete, cancellationToken);
    }

    #endregion

    #region PATCH

#if !NETSTANDARD2_0

    public Task<(string?, HttpStatusCode)> PatchAsync(string url, string body, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> PatchAsync(HttpRequest request, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request.httpRequest, HttpMethod.Patch, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> PatchAsync<T>(string url, string body, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Patch, body, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> PatchAsync<T>(HttpRequest request, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(request.httpRequest, HttpMethod.Patch, cancellationToken);
    }

#endif
    #endregion

    #region PUT

    public Task<(string?, HttpStatusCode)> PutAsync(string url, string body, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(url, HttpMethod.Put, body, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> PutAsync<T>(HttpRequest request, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(request.httpRequest, HttpMethod.Put, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> PutAsync<T>(string url, string body, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Put, body, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> PutAsync(HttpRequest request, CancellationToken cancellationToken = default)
    {
        return SendAsync<string>(request.httpRequest, HttpMethod.Put, cancellationToken);
    }

    #endregion

    #region HEAD

    public Task<(string?, HttpStatusCode)> HeadAsync(string url, CancellationToken cancellationToken = default)
    {
        return HeadAsync<string>(url, cancellationToken);
    }

    public Task<(string?, HttpStatusCode)> HeadAsync(HttpRequest request, CancellationToken cancellationToken = default)
    {
        return HeadAsync<string>(request, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> HeadAsync<T>(string url, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, HttpMethod.Head, cancellationToken);
    }

    public Task<(T?, HttpStatusCode)> HeadAsync<T>(HttpRequest request, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(request.httpRequest, HttpMethod.Head, cancellationToken);
    }

    #endregion

    private Task<(T?, HttpStatusCode)> SendAsync<T>(string url, HttpMethod method, CancellationToken cancellationToken = default) where T : class
    {
        return SendAsync<T>(url, method, null, cancellationToken);
    }

    private Task<(T?, HttpStatusCode)> SendAsync<T>(string url, HttpMethod method, string? body = null, CancellationToken cancellationToken = default) where T : class
    {
        var httpRequest = new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri(url),
        };

        if (!string.IsNullOrEmpty(body))
        {
            httpRequest.Content = new StringContent(body, _encoding, _mediaType);
        }

        return SendAsync<T>(httpRequest, cancellationToken);
    }

    private Task<(T?, HttpStatusCode)> SendAsync<T>(HttpRequestMessage request, HttpMethod method, CancellationToken cancellationToken = default) where T : class
    {
        request.Method = method;
        return SendAsync<T>(request, cancellationToken);
    }

    private async Task<(T?, HttpStatusCode)> SendAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken = default) where T : class
    {
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return (await ReadContentAsync<T>(response, cancellationToken), response.StatusCode);
    }

    private static async Task<T?> ReadContentAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken = default) where T : class
    {
        if (typeof(T) == typeof(string))
        {
            return (await ReadAsStringByFrameWorkVersion(response.Content, cancellationToken)) as T;
        }

        if (typeof(T) == typeof(byte[]))
        {
            return (await ReadAsByteArrayAsyncByFrameWorkVersion(response.Content, cancellationToken)) as T;
        }

        var stringVal = await ReadAsStringByFrameWorkVersion(response.Content, cancellationToken);
        if (stringVal is null) return default;

        try
        {
            return JsonSerializer.Deserialize<T>(stringVal);
        }
        catch (Exception ex)
        {
            throw new SerializationException(stringVal, "Error when attempting to serialize response. See exception details", ex);
        }
    }

    private static Task<string> ReadAsStringByFrameWorkVersion(HttpContent content, CancellationToken cancellationToken)
    {
#if NETSTANDARD2_0
    return content.ReadAsStringAsync();
#else
        return content.ReadAsStringAsync(cancellationToken);
#endif
    }

    private static Task<byte[]> ReadAsByteArrayAsyncByFrameWorkVersion(HttpContent content, CancellationToken cancellationToken)
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
            client.Dispose();
        }
    }
}