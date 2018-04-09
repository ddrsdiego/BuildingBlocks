using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Topology
{
    public interface IQueueBindingEntity
    {
        IDictionary<string, object> Arguments { get; }
        IExchange Exchange { get; }
        string Id { get; }
        IQueue Queue { get; }
        string RoutingKey { get; }
    }
}