using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("LightRest.Test")]
namespace LightRest
{
    public class HttpRequest : IDisposable
    {
        internal HttpRequestMessage httpRequest;
        private Dictionary<string, string>? _parameters;

        public HttpRequest()
        {
            httpRequest = new HttpRequestMessage();
        }

        public HttpRequest AddHeader(string key, string? value)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(key);

            httpRequest.Headers.TryAddWithoutValidation(key, value);
            return this;
        }

        public HttpRequest SetUrl(string url)
        {
            httpRequest.RequestUri = new Uri(url);
            return this;
        }

        public HttpRequest MakeParametersUrlEncoded()
        {
            if (_parameters is null)
            {
                return this;
            }
            httpRequest.Content = new FormUrlEncodedContent(_parameters);
            return this;
        }

        public HttpRequest AddParameter(string key, string value)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(key);
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(value);

            if (_parameters is null)
            {
                _parameters = new Dictionary<string, string>();
            }

            _parameters.Add(key, value);
            return this;
        }

        public HttpRequest AddBody(string body)
        {
            httpRequest.Content = new StringContent(body, Encoding.UTF8);
            return this;
        }

        public HttpRequest ClearHeaders()
        {
            httpRequest.Headers.Clear();
            return this;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                httpRequest.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
