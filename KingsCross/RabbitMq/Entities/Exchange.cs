using Easynvest.BuildingBlocks.KingsCross.RabbitMq.Topology;
using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Entities
{
    public class ExchangeEntity : IExchange
    {
        public ExchangeEntity(string exchangeName, string exchangeType, bool durable, bool autoDelete, IDictionary<string, object> exchangeArguments)
        {
            ExchangeName = exchangeName;
            ExchangeType = exchangeType;
            Durable = durable;
            AutoDelete = autoDelete;
            ExchangeArguments = exchangeArguments ?? new Dictionary<string, object>(); 
        }

        public string ExchangeName { get; }
        public string ExchangeType { get; }
        public bool Durable { get; }
        public bool AutoDelete { get; }
        public IDictionary<string, object> ExchangeArguments { get; }
    }
}
