#if !NETSTANDARD2_0
using System.Net.Http.Json;
#endif

using System.Text.Json;

namespace LightRest;

internal static class HttpContentHelper
{
    internal static Task<string> ReadAsStringAsync(HttpContent content, CancellationToken cancellationToken)
    {
        if (content is null)
        {
            return Task.FromResult(string.Empty);
        }

#if NETSTANDARD2_0
        return content.ReadAsStringAsync();
#else
        return content.ReadAsStringAsync(cancellationToken);
#endif
    }

    internal static Task<byte[]> ReadAsByteArrayAsync(HttpContent content, CancellationToken cancellationToken)
    {
        if (content is null)
        {
            return Task.FromResult(Array.Empty<byte>());
        }

#if NETSTANDARD2_0
        return content.ReadAsByteArrayAsync();
#else
        return content.ReadAsByteArrayAsync(cancellationToken);
#endif
    }

    internal static Task<Stream> ReadAsStreamAsync(HttpContent content, CancellationToken cancellationToken)
    {
        if (content is null)
        {
            return Task.FromResult(Stream.Null);
        }

#if NETSTANDARD2_0
        return content.ReadAsStreamAsync();
#else
        return content.ReadAsStreamAsync(cancellationToken);
#endif
    }

    internal static Task<T?> ReadAsJsonAsync<T>(HttpContent content, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (content is null)
        {
            return Task.FromResult<T?>(default);
        }

#if NETSTANDARD2_0
        return content.ReadAsJsonNetStandardAsync<T>(options, cancellationToken);

#else
        return content.ReadFromJsonAsync<T>(options, cancellationToken);
#endif
    }

#if NETSTANDARD2_0
    internal static async Task<T?> ReadAsJsonNetStandardAsync<T>(this HttpContent content, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        using var stream = await content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<T>(stream, options, cancellationToken).ConfigureAwait(false);
    }
#endif
}
