using System.Threading.Tasks;

namespace Easynvest.BuildingBlocks.App.AggregateModel.TreasuryDirectAggregateModel
{
    public interface ISellTreasuryDirectStepsService
    {
        Task<SellTreasuryDirectStepResponse> Pull(SellTreasuryDirectSteps step);
    }
}