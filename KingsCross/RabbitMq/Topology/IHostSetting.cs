namespace Easynvest.BuildingBlocks.KingsCross.RabbitMq.Topology
{
    public interface IHostSetting
    {
        string UserName { get; }
        string Password { get; }
        int Port { get; }
        string VirtualHost { get; }
    }
}
