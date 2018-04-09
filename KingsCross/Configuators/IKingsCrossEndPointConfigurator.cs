using Easynvest.BuildingBlocks.KingsCross.RabbitMq.Configuators;
using MediatR;
using System;

namespace Easynvest.BuildingBlocks.KingsCross
{
    public interface IKingsCrossEndPointConfigurator
    {
        void SubScriber<T>() where T : IRequest<Unit>;

        void SubScriber<T>(Action<IKingsCrossSubScriberConfigurator> configSubscriber) where T : IRequest<Unit>;
    }

    public interface IKingsCrossSubScriberConfigurator : IQueueConfigurator, IExchangeConfigurator
    {
        bool DeadLetterExchange { get; set; }
    }
}