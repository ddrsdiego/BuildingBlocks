using Easynvest.BuildingBlocks.KingsCross.RabbitMq.Topology;
using Easynvest.BuildingBlocks.KingsCross.Settings;
using System;

namespace Easynvest.BuildingBlocks.KingsCross.Configuators
{
    public interface IKingsCrossConfigurator
    {
        IHostSetting CreateHost(string connectionString, Action<IHostSettingParameters> parameters);

        void ReceiveEndPoint(IHostSetting hostSetting, string queueName, Action<IKingsCrossEndPointConfigurator> endPointConfig);
    }
}
