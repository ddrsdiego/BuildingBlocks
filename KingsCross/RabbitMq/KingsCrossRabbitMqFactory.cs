using Easynvest.BuildingBlocks.KingsCross.RabbitMq.Configuators;
using System;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq
{
    public static class KingsCrossRabbitMqFactory
    {
        private static IKingsCrossRabbitMqConfigurator _kingsCrossRabbitMqConfigurator;

        public static IKingsCross CreateKingsCrossRabbitMq(this IKingsCrossFactory kingsCrossFactory, Action<IKingsCrossRabbitMqConfigurator> kingsCrossConfig)
        {
            if (kingsCrossConfig == null)
            {
                throw new ArgumentNullException(nameof(kingsCrossConfig));
            }

            _kingsCrossRabbitMqConfigurator = new KingsCrossRabbitMqConfigurator();

            kingsCrossConfig?.Invoke(_kingsCrossRabbitMqConfigurator);

            return null;
        }
    }
}
