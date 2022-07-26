namespace LightRest.Test
{
    public class HttpRequestTest
    {
        private HttpRequest request;

        [SetUp]
        public void Setup()
        {
            request = new HttpRequest();
        }

        [Test]
        public void AddHeader_Should_Add_Headers()
        {
            request.AddHeader("requestTraceId", "123");
            request.AddHeader("Authorization", "token");

            var vals = request.httpRequest.Headers.ToDictionary(a => a.Key, a => a.Value);
            Assert.Multiple(() =>
            {
                Assert.That(request.httpRequest.Headers.Count(), Is.EqualTo(2));
                Assert.That(vals["requestTraceId"].First(), Is.EqualTo("123"));
                Assert.That(vals["Authorization"].First(), Is.EqualTo("token"));
            });
        }

        [Test]
        public void AddHeader_Should_Throw_For_Null_Key()
        {
            Assert.Throws<ArgumentNullException>(() => request.AddHeader(null, "val"));
        }

        [Test]
        public void AddHeader_Should_Throw_For_Empty_Key()
        {
            Assert.Throws<ArgumentNullException>(() => request.AddHeader("", "val"));
        }
    }
}