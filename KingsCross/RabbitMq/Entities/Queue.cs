using Easynvest.BuildingBlocks.KingsCross.RabbitMq.Topology;
using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Entities
{
    public class QueueEntity : IQueue
    {
        public QueueEntity(string queueName, bool exclusive, bool durable, bool autoDelete, IDictionary<string, object> arguments)
        {
            QueueName = queueName;
            Exclusive = exclusive;
            Durable = durable;
            AutoDelete = autoDelete;
            Arguments = arguments ?? new Dictionary<string, object>();
        }

        public string QueueName { get; }
        public bool Exclusive { get; }
        public bool Durable { get; }
        public bool AutoDelete { get; }
        public IDictionary<string, object> Arguments { get; }
    }
}
