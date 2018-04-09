using System;
using Easynvest.BuildingBlocks.KingsCross.RabbitMq.Topology;
using Easynvest.BuildingBlocks.KingsCross.Settings;
using Easynvest.BuildingBlocks.KingsCross.RabbitMq.Settings;
using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Configuators
{
    public class KingsCrossRabbitMqConfigurator : IKingsCrossRabbitMqConfigurator
    {
        private IHostSettingParameters _hostSettingParameters;
        private IKingsCrossEndPointConfigurator _kingsCrossEndPointConfigurator;
        private List<IKingsCrossEndPointConfigurator> _kingsCrossEndPointConfigurators;

        public KingsCrossRabbitMqConfigurator()
        {
            _hostSettingParameters = new RabbitMqHostSettingParameters();
            _kingsCrossEndPointConfigurator = new RabbitMqKingsCrossEndPointConfigurator();
            _kingsCrossEndPointConfigurators = new List<IKingsCrossEndPointConfigurator>();
        }

        public IHostSetting CreateHost(string hostName, Action<IHostSettingParameters> parameters)
        {
            if (string.IsNullOrEmpty(hostName))
            {
                throw new ArgumentException("message", nameof(hostName));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            parameters?.Invoke(_hostSettingParameters);

            return _hostSettingParameters.GetHostSetting(hostName);
        }

        public void ReceiveEndPoint(IHostSetting hostSetting, string queueName, Action<IKingsCrossEndPointConfigurator> endPointConfig)
        {
            if (endPointConfig == null)
            {
                throw new ArgumentNullException(nameof(endPointConfig));
            }

            endPointConfig?.Invoke(_kingsCrossEndPointConfigurator);

            _kingsCrossEndPointConfigurators.Add(_kingsCrossEndPointConfigurator);
        }
    }
}
