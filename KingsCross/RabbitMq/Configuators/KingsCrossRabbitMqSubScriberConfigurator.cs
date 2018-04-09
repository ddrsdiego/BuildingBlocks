using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Configuators
{
    public class KingsCrossRabbitMqSubScriberConfigurator : IKingsCrossSubScriberConfigurator
    {
        private KingsCrossRabbitMqSubScriberConfigurator()
        {
            QueueArguments = new Dictionary<string, object>();
            ExchangeArguments = new Dictionary<string, object>();
        }

        public bool DeadLetterExchange { get; set; }

        public bool AutoDelete { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public string QueueName { get; set; }

        public IDictionary<string, object> QueueArguments { get; }
        public IDictionary<string, object> ExchangeArguments { get; }

        public string ExchangeName { get; set; }
        public string ExchangeType { get; set; }

        public void SetExchangeArgument(string key, object value)
        {
            if (!ExchangeArguments.ContainsKey(key))
                ExchangeArguments.Add(key, value);
        }

        public void SetQueueArguments(string key, object value)
        {
            if (!QueueArguments.ContainsKey(key))
                QueueArguments.Add(key, value);
        }

        public static KingsCrossRabbitMqSubScriberConfigurator CreateRabbitMqSubScriberDefault()
        {
            return new KingsCrossRabbitMqSubScriberConfigurator
            {
                DeadLetterExchange = false,
                ExchangeType = RabbitMQ.Client.ExchangeType.Direct
            };
        }
    }
}
