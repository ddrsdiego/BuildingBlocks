using System.Threading.Tasks;

namespace Easynvest.BuildingBlocks.App.AggregateModel.TreasuryDirectAggregateModel
{
    public class GetBaskIdFromMarket : SellTreasuryDirectSteps
    {
        public GetBaskIdFromMarket(ISellTreasuryDirectStepRequest request)
            : base(request)
        {

        }

        public override async Task<SellTreasuryDirectStepResponse> Pull()
        {
            var marketId = (_request as GetBaskIdFromMarketResquest).MarketId;
            var customerId = (_request as GetBaskIdFromMarketResquest).CustomerId;

            return await Task.FromResult<SellTreasuryDirectStepResponse>(new SellTreasuryDirectStepResponse
            {
                Id = "1",
                Description = "SUCCESS"
            });
        }
    }

    public class GetBaskIdFromMarketResquest : ISellTreasuryDirectStepRequest
    {
        public GetBaskIdFromMarketResquest(string customerId, string marketId)
        {
            CustomerId = customerId;
            MarketId = marketId;
        }

        public string CustomerId { get; }
        public string MarketId { get; }
    }
}
