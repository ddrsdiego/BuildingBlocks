using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Net.Http;

namespace Easynvest.BuildingBlocks.Resilience.Http
{
    public class ResilientHttpClientFactory : IResilientHttpClientFactory
    {
        private readonly ILogger<ResilientHttpClient> _logger;

        public ResilientHttpClientFactory()
        {
        }

        public ResilientHttpClientFactory(ILogger<ResilientHttpClient> logger)
        {
            _logger = logger;
        }

        public ResilientHttpClient CreateResilientHttpClient() =>
            new ResilientHttpClient(origin => CreatePolicies(), _logger);

        private Policy[] CreatePolicies()
        {
            return new Policy[]
            {
                Policy.Handle<HttpRequestException>()
                .WaitAndRetryAsync(
                    6,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, retryCount, context) =>
                    {
                        var msg = $"Retry {retryCount} implemented with Polly's RetryPolicy " +
                                    $"of {context.PolicyKey} " +
                                    $"at {context.ExecutionKey}, " +
                                    $"due to: {exception}.";
                        _logger.LogWarning(msg);
                        _logger.LogDebug(msg);
                    }),
                Policy.Handle<HttpRequestException>()
                .CircuitBreakerAsync(
                   5,
                   TimeSpan.FromMinutes(1),
                   (exception, duration) =>
                   {
                        _logger.LogTrace("Circuit breaker opened");
                   },
                   () =>
                   {
                        _logger.LogTrace("Circuit breaker reset");
                   })
            };
        }
    }
}