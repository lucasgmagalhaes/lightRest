using System.Net;
using System.Text;
using System.Text.Json;

namespace LightRest;
public interface ILightClient : IDisposable
{
    /// <summary>
    /// Defines the default media type for requests
    /// </summary>
    string? MediaType { get; set; }
    
    /// <summary>
    /// Defines the encoding for serialization
    /// </summary>
    Encoding? Encoding { get; set; }
    
    /// <summary>
    /// Defines if an exception should be thrown in case of status code of failure
    /// in requests
    /// </summary>
    bool EnsureSuccess { get; set; }

    /// <summary>
    /// Defines the serialization options
    /// </summary>
    JsonSerializerOptions SerializerOptions { get; set; }
    TimeSpan Timeout { get; set; }
    long MaxResponseContentBufferSize { get; set; }

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
    Task<(string?, HttpStatusCode)> DeleteAsync(in string url, in object? body = default, CancellationToken cancellationToken = default);

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
    Task<(string?, HttpStatusCode)> DeleteAsync(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

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
    Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

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
    Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

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
    Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class;

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
    Task<(TResponse?, HttpStatusCode)> DeleteAsync<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class;

    /// <summary>
    /// Send a DELETE request to the specified Uri with a cancellation token as an synchronous operation
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
    (string?, HttpStatusCode) Delete(in string url, in object? body = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a DELETE request to the specified Uri with a cancellation token as an synchronous operation
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
    (string?, HttpStatusCode) Delete(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a DELETE request to the specified Uri with a cancellation token as an synchronous operation
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
    (TResponse?, HttpStatusCode) Delete<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a DELETE request to the specified Uri with a cancellation token as an synchronous operation
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
    (TResponse?, HttpStatusCode) Delete<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a DELETE request to the specified Uri with a cancellation token as an synchronous operation
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
    (TResponse?, HttpStatusCode) Delete<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

    /// <summary>
    /// Send a DELETE request to the specified Uri with a cancellation token as an synchronous operation
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
    (TResponse?, HttpStatusCode) Delete<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

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
    Task<(string?, HttpStatusCode)> GetAsync(in string url, in object? body = default, CancellationToken cancellationToken = default);

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
    Task<(string?, HttpStatusCode)> GetAsync(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

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
    Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

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
    Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a GET request to the specified Uri with a cancellation token as an asynchronous operation
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <typeparam name="TRequest">Type of the body</typeparam>
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
    Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class;

    /// <summary>
    /// Send a GET request to the specified Uri with a cancellation token as an asynchronous operation
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <typeparam name="TRequest">Type of the body</typeparam>
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
    Task<(TResponse?, HttpStatusCode)> GetAsync<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class;


    /// <summary>
    /// Send a GET request to the specified Uri with a cancellation token as an synchronous operation
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
    (string?, HttpStatusCode) Get(in string url, in object? body = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a GET request to the specified Uri with a cancellation token as an synchronous operation
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
    (string?, HttpStatusCode) Get(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a GET request to the specified Uri with a cancellation token as an synchronous operation
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
    (TResponse?, HttpStatusCode) Get<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a GET request to the specified Uri with a cancellation token as an synchronous operation
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
    (TResponse?, HttpStatusCode) Get<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a GET request to the specified Uri with a cancellation token as an synchronous operation
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <typeparam name="TRequest">Type of the body</typeparam>
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
    (TResponse?, HttpStatusCode) Get<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

    /// <summary>
    /// Send a GET request to the specified Uri with a cancellation token as an synchronous operation
    /// </summary>
    /// <typeparam name="TResponse">Type for the response</typeparam>
    /// <typeparam name="TRequest">Type of the body</typeparam>
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
    (TResponse?, HttpStatusCode) Get<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

    /// <summary>
    ///  Send a GET request to the specified Uri and return the response body as a byte
    ///  array in an synchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <returns> The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    byte[] GetByteArray(in string url);

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a byte
    /// array in an synchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    byte[] GetByteArray(in Uri url);

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
    /// Send a GET request to the specified Uri and return the response body as a stream
    /// in an synchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    Stream GetStream(in string url);

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a stream
    /// in an synchronous operation.
    /// </summary>
    /// <param name="url">The Uri the request is sent to.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    Stream GetStream(in Uri url);

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
    /// Send a GET request to the specified Uri and return the response body as a string
    /// in an synchronous operation.
    /// </summary>
    /// <param name="url"> The Uri the request is sent to.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    string GetString(in string url);

    /// <summary>
    /// Send a GET request to the specified Uri and return the response body as a string
    /// in an synchronous operation.
    /// </summary>
    /// <param name="url"> The Uri the request is sent to.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The requestUri was null.</exception>
    /// <exception cref="HttpRequestException">
    /// The request failed due to an underlying issue such as network connectivity, DNS
    /// failure, server certificate validation or timeout.
    /// </exception>
    string GetString(in Uri url);

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
    Task<(string?, HttpStatusCode)> HeadAsync(in string url, in object? body = default, CancellationToken cancellationToken = default);

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
    Task<(string?, HttpStatusCode)> HeadAsync(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

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
    Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

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
    Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

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
    Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class;

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
    Task<(TResponse?, HttpStatusCode)> HeadAsync<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class;

    /// <summary>
    /// Send a HEAD request as an synchronous operation.
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
    (string?, HttpStatusCode) Head(in string url, in object? body = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a HEAD request as an synchronous operation.
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
    (string?, HttpStatusCode) Head(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a HEAD request as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Head<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a HEAD request as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Head<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a HEAD request as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Head<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

    /// <summary>
    /// Send a HEAD request as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Head<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

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
    Task<(string?, HttpStatusCode)> PostAsync(in string url, in object? body = default, CancellationToken cancellationToken = default);

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
    Task<(string?, HttpStatusCode)> PostAsync(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

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
    Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

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
    Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

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
    Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class;

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
    Task<(TResponse?, HttpStatusCode)> PostAsync<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class;

    /// <summary>
    /// Send a POST request with a cancellation token as an synchronous operation.
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
    (string?, HttpStatusCode) Post(in string url, in object? body = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a POST request with a cancellation token as an synchronous operation.
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
    (string?, HttpStatusCode) Post(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a POST request with a cancellation token as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Post<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a POST request with a cancellation token as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Post<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a POST request with a cancellation token as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Post<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

    /// <summary>
    /// Send a POST request with a cancellation token as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Post<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

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
    Task<(string?, HttpStatusCode)> PutAsync(in string url, in object? body = default, CancellationToken cancellationToken = default);

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
    Task<(string?, HttpStatusCode)> PutAsync(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

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
    Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

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
    Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

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
    Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class;

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
    Task<(TResponse?, HttpStatusCode)> PutAsync<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default) 
        where TResponse : class
        where TRequest : class;

    /// <summary>
    /// Send a PUT request to the specified Uri as an synchronous operation.
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
    (string?, HttpStatusCode) Put(in string url, in object? body = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a PUT request to the specified Uri as an synchronous operation.
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
    (string?, HttpStatusCode) Put(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send a PUT request with a cancellation token as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Put<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a PUT request with a cancellation token as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Put<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Send a PUT request with a cancellation token as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Put<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

    /// <summary>
    /// Send a PUT request with a cancellation token as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Put<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

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
    /// Send an HTTP request as an synchronous operation.
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
    (string?, HttpStatusCode) Send(in HttpRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send an HTTP request as an synchronous operation.
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
    (TResponse?, HttpStatusCode) Send<TResponse>(in HttpRequest request, CancellationToken cancellationToken = default) where TResponse : class;

    /// <summary>
    /// Defines the base url for the client.
    /// </summary>
    /// <returns></returns>
    ILightClient SetBaseUrl(in string url);

    void CancelPendingRequests();

#if !NETSTANDARD2_0
    Task<(string?, HttpStatusCode)> PatchAsync(in string url, in object? body = default, CancellationToken cancellationToken = default);

    Task<(string?, HttpStatusCode)> PatchAsync(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

    Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

    Task<(TResponse?, HttpStatusCode)> PatchAsync<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

    (string?, HttpStatusCode) Patch(in string url, in object? body = default, CancellationToken cancellationToken = default);

    (string?, HttpStatusCode) Patch(in Uri url, in object? body = default, CancellationToken cancellationToken = default);

    (TResponse?, HttpStatusCode) Patch<TResponse>(in string url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    (TResponse?, HttpStatusCode) Patch<TResponse>(in Uri url, in object? body = default, CancellationToken cancellationToken = default) where TResponse : class;

    (TResponse?, HttpStatusCode) Patch<TResponse, TRequest>(in Uri url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

    (TResponse?, HttpStatusCode) Patch<TResponse, TRequest>(in string url, in TRequest? body = default, CancellationToken cancellationToken = default)
        where TResponse : class
        where TRequest : class;

#endif
}