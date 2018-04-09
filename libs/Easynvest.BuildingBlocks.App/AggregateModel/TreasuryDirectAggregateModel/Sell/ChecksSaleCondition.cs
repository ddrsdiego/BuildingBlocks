using System.Threading.Tasks;

namespace Easynvest.BuildingBlocks.App.AggregateModel.TreasuryDirectAggregateModel
{
    public class ChecksSaleCondition : SellTreasuryDirectSteps
    {
        public ChecksSaleCondition(ISellTreasuryDirectStepRequest request)
            : base(request)
        {

        }

        public override async Task<SellTreasuryDirectStepResponse> Pull()
        {
            var marketId = (_request as ChecksSaleConditionRequest).MarketId;
            var customerId = (_request as ChecksSaleConditionRequest).CustomerId;

            return await Task.FromResult<SellTreasuryDirectStepResponse>(new SellTreasuryDirectStepResponse
            {
                Id = "1",
                Description = "SUCCESS"
            });
        }
    }

    public class ChecksSaleConditionRequest : ISellTreasuryDirectStepRequest
    {
        public ChecksSaleConditionRequest(string customerId, string marketId)
        {
            CustomerId = customerId;
            MarketId = marketId;
        }

        public string CustomerId { get; }
        public string MarketId { get; }
    }
}
