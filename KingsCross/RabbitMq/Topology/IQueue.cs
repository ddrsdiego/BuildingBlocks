using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Topology
{
    public interface IQueue
    {
        IDictionary<string, object> Arguments { get; }
        bool AutoDelete { get; }
        bool Durable { get; }
        bool Exclusive { get; }
        string QueueName { get; }
    }
}