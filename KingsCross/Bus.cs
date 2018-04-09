using System;
using System.Threading.Tasks;

namespace Easynvest.BuildingBlocks.KingsCross
{
    public static class Bus
    {
        public static IKingsCrossFactory Factory { get; }
    }

    public interface IKingsCrossFactory
    {

    }

    public interface IKingsCross
    {
        Task Start();
    }

    public static class KingsCrossStartEx
    {
        public static void Start(this IKingsCross kingsCross)
        {
            kingsCross.Start();
        }
    }
}
