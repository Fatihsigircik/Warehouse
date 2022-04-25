using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace DatabaseServer.Filters
{
    public class AuthenticationFailureResult : IHttpActionResult
    {
        public HttpRequestMessage Request { get; }
        public string ReasonPhrase { get; }

        public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
        {
            Request = request;
            ReasonPhrase = reasonPhrase;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            return new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                RequestMessage = Request,
                ReasonPhrase = ReasonPhrase
            };
        }
    }
}