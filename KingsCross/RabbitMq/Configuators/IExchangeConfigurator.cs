using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Configuators
{
    public interface IExchangeConfigurator
    {
        bool AutoDelete { get; set; }
        bool Durable { get; set; }
        IDictionary<string, object> ExchangeArguments { get; }
        string ExchangeName { get; set; }
        string ExchangeType { get; set; }

        void SetExchangeArgument(string key, object value);
    }
}
