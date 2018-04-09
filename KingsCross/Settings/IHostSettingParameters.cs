using Easynvest.BuildingBlocks.KingsCross.RabbitMq.Topology;

namespace Easynvest.BuildingBlocks.KingsCross.Settings
{
    public interface IHostSettingParameters
    {
        void UserName(string userName);
        void Password(string password);
        void Port(int port);
        void VirtualHost(string virtualHost);

        IHostSetting GetHostSetting(string hostName);
    }
}
