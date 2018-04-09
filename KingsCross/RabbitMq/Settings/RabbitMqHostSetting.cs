using Easynvest.BuildingBlocks.KingsCross.RabbitMq.Topology;
using System;

namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Settings
{
    public class RabbitMqHostSetting : IHostSetting
    {
        private const int PORT_DEFAULT = 5672;
        private const string USERNAME_DEFAULT = "guest";
        private const string PASSWORD_DEFAULT = "guest";
        private const string VIRTUALHOST_DEFAULT = "/";

        public RabbitMqHostSetting(string hostName, int port, string userName, string password, string virtualHost)
        {
            //HostName = hostName;
            Port = port;
            UserName = userName;
            Password = password;
            VirtualHost = virtualHost;

            ValidateParameters();

        }

        public RabbitMqHostSetting(string hostName) :
             this(hostName, PORT_DEFAULT, USERNAME_DEFAULT, PASSWORD_DEFAULT, VIRTUALHOST_DEFAULT)
        {
        }

        public RabbitMqHostSetting(string hostName, string userName, string password)
            : this(hostName, PORT_DEFAULT, userName, password, VIRTUALHOST_DEFAULT)
        {
        }

        public RabbitMqHostSetting(string hostName, int port, string userName, string password)
            : this(hostName, port, userName, password, VIRTUALHOST_DEFAULT)
        {
        }

        public string UserName { get; }

        public string Password { get; }

        public int Port { get; }

        public string VirtualHost { get; }

        private void ValidateParameters()
        {
            if (Port < 0)
            {
                throw new ArgumentNullException(nameof(Port));
            }

            if (string.IsNullOrWhiteSpace(UserName))
            {
                throw new ArgumentNullException(nameof(UserName));
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                throw new ArgumentNullException(nameof(Password));
            }

            if (string.IsNullOrWhiteSpace(VirtualHost))
            {
                throw new ArgumentNullException(nameof(VirtualHost));
            }
        }
    }
}
