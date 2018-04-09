using Easynvest.BuildingBlocks.KingsCross.RabbitMq.Topology;
using Easynvest.BuildingBlocks.KingsCross.Settings;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Settings
{
    public class RabbitMqHostSettingParameters : IHostSettingParameters
    {
        private string _userName;
        private string _password;
        private int _port;
        private string _virtualHost;
        private IHostSetting _hostSetting;

        public void Password(string password)
        {
            _password = password;
        }

        public void Port(int port)
        {
            _port = port;
        }

        public void UserName(string userName)
        {
            _userName = userName;
        }

        public void VirtualHost(string virtualHost)
        {
            _virtualHost = virtualHost;
        }

        public IHostSetting GetHostSetting(string hostName)
        {
            return new RabbitMqHostSetting(hostName, _userName, _password);
        }
    }
}
