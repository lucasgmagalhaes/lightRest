using System.Net;
using System.Text;
using System.Text.Json;

namespace LightRest;
public interface ILightClient
{
    /// <summary>
    /// Adds the specified header and its value into the <see cref="System.Net.Http.Headers.HttpHeaders"/> collection.
    /// </summary>
    /// <param name="name">Name of the header</param>
    /// <param name="values">Header's values</param>
    /// <returns></returns>
    LightClient AddDefaultHeader(in string name, IEnumerable<string> values);

    /// <summary>
    /// Adds the specified header and its value into the <see cref="System.Net.Http.Headers.HttpHeaders"/> collection.
    /// </summary>
    /// <param name="name">Name of the header</param>
    /// <param name="values">Header's value</param>
    /// <returns></returns>
    LightClient AddDefaultHeader(in string name, string value);

    /// <summary>
    /// Clean all default filters
    /// </summary>
    /// <returns></returns>
    LightClient ClearDefaultHeaders();

    /// <summary>
    /// Send a DELETE request to the specified Uri with a cancellation token as an asynchronous operation
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <see cref="string"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<see cref="string"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(string?, HttpStatusCode)> DeleteAsync(in string url, in object? body = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a DELETE request to the specified Uri with a cancellation token as an asynchronous operation
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <see cref="string"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<see cref="string"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(string?, HttpStatusCode)> DeleteAsync(in Uri url, in object? body = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a DELETE request to the specified Uri with a cancellation token as an asynchronous operation
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <typeparamref name="TResponse"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse>(in string url, in object? body = null, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a DELETE request to the specified Uri with a cancellation token as an asynchronous operation
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <typeparamref name="TResponse"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse>(in Uri url, in object? body = null, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a GET request to the specified Uri with a cancellation token as an asynchronous operation
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <see cref="string"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(string?, HttpStatusCode)> GetAsync(in string url, in object? body = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a GET request to the specified Uri with a cancellation token as an asynchronous operation
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <see cref="string"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(string?, HttpStatusCode)> GetAsync(in Uri url, in object? body = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a GET request to the specified Uri with a cancellation token as an asynchronous operation
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <typeparamref name="TResponse"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse>(in string url, in object? body = null, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a GET request to the specified Uri with a cancellation token as an asynchronous operation
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <typeparamref name="TResponse"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse>(in Uri url, in object? body = null, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    ///  Send a GET request to the specified Uri and return the response body as a byte
    ///  array in an asynchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <returns> The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    Task<byte[]> GetByteArrayAsync(in string url);

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a byte
    /// array in an asynchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    Task<byte[]> GetByteArrayAsync(in Uri url);

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a stream
    /// in an asynchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    Task<Stream> GetStreamAsync(in string url);

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a stream
    /// in an asynchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    Task<Stream> GetStreamAsync(in Uri url);

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a string
    /// in an asynchronous operation.
    /// </summary>
    /// <param name="url"> The Uri the request is sent to.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    Task<string> GetStringAsync(in string url);

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a string
    /// in an asynchronous operation.
    /// </summary>
    /// <param name="url"> The Uri the request is sent to.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    Task<string> GetStringAsync(in Uri url);

    /// <summary>
    /// Send a HEAD request as an asynchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">The HTTP request content sent to the server.</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <see cref="string"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<see cref="string"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(string?, HttpStatusCode)> HeadAsync(in string url, in object? body = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a HEAD request as an asynchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">The HTTP request content sent to the server.</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <see cref="string"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<see cref="string"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(string?, HttpStatusCode)> HeadAsync(in Uri url, in object? body = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a HEAD request as an asynchronous operation.
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <typeparamref name="TResponse"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse>(in string url, in object? body = null, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a HEAD request as an asynchronous operation.
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <typeparamref name="TResponse"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse>(in Uri url, in object? body = null, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a POST request with a cancellation token as an asynchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">The HTTP request content sent to the server.</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <see cref="string"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<see cref="string"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(string?, HttpStatusCode)> PostAsync(in string url, in object? body = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a POST request with a cancellation token as an asynchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">The HTTP request content sent to the server.</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <see cref="string"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<see cref="string"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(string?, HttpStatusCode)> PostAsync(in Uri url, in object? body = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a POST request with a cancellation token as an asynchronous operation.
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <typeparamref name="TResponse"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse>(in string url, in object? body = null, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a POST request with a cancellation token as an asynchronous operation.
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <typeparamref name="TResponse"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse>(in Uri url, in object? body = null, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a PUT request to the specified Uri as an asynchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">The HTTP request content sent to the server.</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <see cref="string"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<see cref="string"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(string?, HttpStatusCode)> PutAsync(in string url, in object? body = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a PUT request to the specified Uri as an asynchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">The HTTP request content sent to the server.</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <see cref="string"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<see cref="string"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(string?, HttpStatusCode)> PutAsync(in Uri url, in object? body = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a PUT request with a cancellation token as an asynchronous operation.
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <typeparamref name="TResponse"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse>(in string url, in object? body = null, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a PUT request with a cancellation token as an asynchronous operation.
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <param name="body">Optional body for the request</param>
    /// <param name="cancellationToken">
    ///  A cancellation token that can be used by other objects or threads to receive
    ///  notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <typeparamref name="TResponse"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse>(in Uri url, in object? body = null, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send an HTTP request as an asynchronous operation.
    /// </summary>
    /// <param name="request">The HTTP request message to send.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive
    /// notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <see cref="string"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<see cref="string"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(string?, HttpStatusCode)> SendAsync(in HttpRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send an HTTP request as an asynchronous operation.
    /// </summary>
    /// <param name="request">The HTTP request message to send.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive
    /// notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <see cref="string"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<see cref="string"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(string?, HttpStatusCode)> SendAsync(in HttpRequestMessage request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send an HTTP request as an asynchronous operation.
    /// </summary>
    /// <param name="request">The HTTP request message to send.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive
    /// notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <typeparamref name="TResponse"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(HttpRequestMessage request, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send an HTTP request as an asynchronous operation.
    /// </summary>
    /// <param name="request">The HTTP request message to send.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive
    /// notice of cancellation.
    /// </param>
    /// <returns>
    /// A tuple with the is a optional <typeparamref name="TResponse"/> and 
    /// the <see cref="HttpStatusCode"/> of the request
    /// </returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="InvalidOperationException">
    /// The request message was already sent by the System.Net.Http.HttpClient instance.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    /// <exception cref="SerializationException">
    /// The serialization for the given type (<typeparamref name="TResponse"/>) failed.
    /// See inner exceptions for more details.
    /// </exception>
    Task<(TResponse?, HttpStatusCode)> SendAsync<TResponse>(in HttpRequest request, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Defines the base url for the client.
    /// </summary>
    /// <returns></returns>
    ILightClient SetBaseUrl(in string url);

    /// <summary>
    /// Defines the encoding for serialization
    /// </summary>
    /// <param name="encoding"></param>
    /// <returns></returns>
    ILightClient SetEncoding(in Encoding? encoding);

    /// <summary>
    /// Defines if an exception should be thrown in case of status code of failure
    /// in requests
    /// </summary>
    /// <returns></returns>
    ILightClient SetEnsureSuccess(in bool ensure);

    /// <summary>
    /// Defines the default media type for requests
    /// </summary>
    /// <param name="media"></param>
    /// <returns></returns>
    ILightClient SetMediaType(in string? media);

    /// <summary>
    /// Defines the serialization options
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    ILightClient SetSerializerOptions(in JsonSerializerOptions options);

#if !NETSTANDARD2_0
    Task<(string?, HttpStatusCode)> PatchAsync(in string url, in object? body = default, CancellationToken cancellationToken = default);

    Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    Task<(string?, HttpStatusCode)> PatchAsync(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

    Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

#endif
}