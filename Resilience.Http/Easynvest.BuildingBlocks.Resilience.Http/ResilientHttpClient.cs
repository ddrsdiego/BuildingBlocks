using Microsoft.Extensions.Logging;
using System;
using Polly;
using Polly.Wrap;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;

namespace Easynvest.BuildingBlocks.Resilience.Http
{
    public class ResilientHttpClient : IHttpClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<ResilientHttpClient> _logger;
        private readonly Func<string, IEnumerable<Policy>> _policyCreator;
        private ConcurrentDictionary<string, PolicyWrap> _policyWrappers;

        public ResilientHttpClient(Func<string, IEnumerable<Policy>> policyCreator, ILogger<ResilientHttpClient> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _policyCreator = policyCreator;
            _policyWrappers = new ConcurrentDictionary<string, PolicyWrap>();
        }

        public async Task<string> GetStringAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var origin = GetOriginFromUri(uri);

            return await HttpInvoker(origin, async () =>
             {
                 var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

                 if (authorizationToken != null)
                     requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod, authorizationToken);

                 var response = await _client.SendAsync(requestMessage);

                 if (response.StatusCode == HttpStatusCode.InternalServerError)
                     throw new HttpRequestException();

                 return await response.Content.ReadAsStringAsync();
             });
        }

        public Task<HttpResponseMessage> DeleteAsync(string uri, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PostAsync<T>(string uri, T item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PutAsync<T>(string uri, T item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            throw new NotImplementedException();
        }

        private async Task<T> HttpInvoker<T>(string origin, Func<Task<T>> action)
        {
            var normalizedOrigin = NormalizeOrigin(origin);

            if (!_policyWrappers.TryGetValue(normalizedOrigin, out PolicyWrap policyWrap))
            {
                policyWrap = Policy.WrapAsync(_policyCreator(normalizedOrigin).ToArray());
                _policyWrappers.TryAdd(normalizedOrigin, policyWrap);
            }

            // Executes the action applying all 
            // the policies defined in the wrapper
            return await policyWrap.ExecuteAsync(action, new Context(normalizedOrigin));
        }

        private static string NormalizeOrigin(string origin) => origin?.Trim()?.ToLower();

        private static string GetOriginFromUri(string uri)
        {
            var url = new Uri(uri);

            var origin = $"{url.Scheme}://{url.DnsSafeHost}:{url.Port}";

            return origin;
        }
    }
}
