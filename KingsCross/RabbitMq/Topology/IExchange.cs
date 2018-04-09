using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Topology
{
    public interface IExchange
    {
        bool AutoDelete { get; }
        bool Durable { get; }
        IDictionary<string, object> ExchangeArguments { get; }
        string ExchangeName { get; }
        string ExchangeType { get; }
    }
}