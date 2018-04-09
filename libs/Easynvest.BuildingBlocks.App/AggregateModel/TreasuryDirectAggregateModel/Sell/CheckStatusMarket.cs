using System.Threading.Tasks;

namespace Easynvest.BuildingBlocks.App.AggregateModel.TreasuryDirectAggregateModel
{
    public class CheckStatusMarket : SellTreasuryDirectSteps
    {
        public CheckStatusMarket(ISellTreasuryDirectStepRequest request)
            : base(request)
        {

        }

        public override async Task<SellTreasuryDirectStepResponse> Pull()
        {
            return await Task.FromResult<SellTreasuryDirectStepResponse>(new SellTreasuryDirectStepResponse
            {
                Id = "1",
                Description = "SUCCESS"
            });
        }
    }

    public class CheckStatusMarketRequest : ISellTreasuryDirectStepRequest
    {

    }
}
