using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Configuators
{
    public interface IQueueConfigurator
    {
        IDictionary<string, object> QueueArguments { get; }
        bool AutoDelete { get; set; }
        bool Durable { get; set; }
        bool Exclusive { get; set; }
        string QueueName { get; set; }

        void SetQueueArguments(string key, object value);
    }
}
