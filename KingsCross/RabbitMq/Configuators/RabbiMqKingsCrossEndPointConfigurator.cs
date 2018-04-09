using System;
using MediatR;
using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Configuators
{
    public class RabbitMqKingsCrossEndPointConfigurator : IKingsCrossEndPointConfigurator
    {
        private IKingsCrossSubScriberConfigurator _subScriberConfigurator;
        private List<IKingsCrossSubScriberConfigurator> _subScriberConfigurators;

        public RabbitMqKingsCrossEndPointConfigurator()
        {
            _subScriberConfigurators = new List<IKingsCrossSubScriberConfigurator>();
        }

        public void SubScriber<T>() where T : IRequest<Unit>
        {
            SubScriber<T>(configSubscriber => 
            {

            });
        }

        public void SubScriber<T>(Action<IKingsCrossSubScriberConfigurator> configSubscriber) where T : IRequest<Unit>
        {
            _subScriberConfigurator = KingsCrossRabbitMqSubScriberConfigurator.CreateRabbitMqSubScriberDefault();

            configSubscriber?.Invoke(_subScriberConfigurator);

            _subScriberConfigurators.Add(_subScriberConfigurator);
        }
    }
}