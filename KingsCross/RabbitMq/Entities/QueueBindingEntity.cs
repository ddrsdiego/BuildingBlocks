using Easynvest.BuildingBlocks.KingsCross.RabbitMq.Topology;
using System;
using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Entities
{
    public class QueueBindingEntity : IQueueBindingEntity
    {
        public QueueBindingEntity(IExchange exchange, IQueue queue, string routingKey, IDictionary<string, object> arguments)
        {
            Id = Guid.NewGuid().ToString("N");
            Exchange = exchange;
            Queue = queue;
            RoutingKey = routingKey;
            Arguments = arguments ?? throw new ArgumentNullException(nameof(arguments));
        }

        public string Id { get; }
        public IExchange Exchange { get; }
        public IQueue Queue { get; }
        public string RoutingKey { get; }
        public IDictionary<string, object> Arguments { get; }
    }
}
