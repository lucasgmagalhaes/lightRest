using LightRest.Extensions;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("LightRest.Test")]
namespace LightRest;

public class HttpRequest : IDisposable
{
    internal readonly HttpRequestMessage _httpRequest;

    private List<KeyValuePair<string?, string?>>? _parameters;

    public HttpRequest(string url, Method method)
    {
        _httpRequest = new HttpRequestMessage
        {
            Method = method.GetHttpMethod(),
            RequestUri = new Uri(url)
        };
    }

    public HttpRequest()
    {
        _httpRequest = new HttpRequestMessage();
    }

#if NET5_0_OR_GREATER
    [Obsolete("HttpRequestMessage.Properties has been deprecated. Use Options instead.")]
#endif
    public HttpRequest AddProperty(string key, object value)
    {
        _httpRequest.Properties.Add(key, value);
        return this;
    }

#if NET5_0_OR_GREATER
    [Obsolete("HttpRequestMessage.Properties has been deprecated. Use Options instead.")]
#endif
    public HttpRequest AddProperty(KeyValuePair<string, object?> keyValue)
    {
        _httpRequest.Properties.Add(keyValue);
        return this;
    }

#if NET5_0_OR_GREATER
    [Obsolete("HttpRequestMessage.Properties has been deprecated. Use Options instead.")]
#endif
    public HttpRequest ClearProperties()
    {
        _httpRequest.Properties.Clear();
        return this;
    }

    public HttpRequest AddHeader(string key, string value)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(key);

        _httpRequest.Headers.Add(key, value);
        return this;
    }

    public HttpRequest AddHeader(string key, IEnumerable<string> values)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(key);

        _httpRequest.Headers.Add(key, values);
        return this;
    }

    public HttpRequest ClearHeaders()
    {
        _httpRequest.Headers.Clear();
        return this;
    }

    public HttpRequest SetUrl(string url)
    {
        _httpRequest.RequestUri = new Uri(url);
        return this;
    }

    public HttpRequest SetUrl(Uri url)
    {
        _httpRequest.RequestUri = url;
        return this;
    }

#if NET5_0_OR_GREATER

    public HttpRequest SetOptions(string key, object? value)
    {
        _httpRequest.Options.TryAdd(key, value);
        return this;
    }

#endif

    public HttpRequest MakeParametersUrlEncoded()
    {
        if (_parameters is null)
        {
            return this;
        }
        _httpRequest.Content = new FormUrlEncodedContent(_parameters);
        return this;
    }

    public HttpRequest AddParameter(string key, string value)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(key);
        if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(value);

        _parameters ??= new();

        _parameters.Add(new KeyValuePair<string?, string?>(key, value));
        return this;
    }

    public HttpRequest SetBody(string body, Encoding? encoding = null, string? mediaType = null)
    {
        _httpRequest.Content = new StringContent(body, encoding, mediaType);
        return this;
    }

    public HttpRequest SetBody(HttpContent body)
    {
        _httpRequest.Content = body;
        return this;
    }

    public HttpRequest SetMethod(HttpMethod method)
    {
        _httpRequest.Method = method;
        return this;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _httpRequest.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
