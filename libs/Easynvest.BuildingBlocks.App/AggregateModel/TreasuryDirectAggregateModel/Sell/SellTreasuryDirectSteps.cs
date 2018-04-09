using System.Threading.Tasks;

namespace Easynvest.BuildingBlocks.App.AggregateModel.TreasuryDirectAggregateModel
{
    public abstract class SellTreasuryDirectSteps
    {
        protected readonly ISellTreasuryDirectStepRequest _request;
        protected SellTreasuryDirectSteps(ISellTreasuryDirectStepRequest request)
        {
            this._request = request;
        }

        public abstract Task<SellTreasuryDirectStepResponse> Pull();
    }

    public class SellTreasuryDirectStepsService : ISellTreasuryDirectStepsService
    {
        public Task<SellTreasuryDirectStepResponse> Pull(SellTreasuryDirectSteps step)
        {
            return step.Pull();
        }
    }

    public interface ISellTreasuryDirectStepRequest
    {

    }
}
