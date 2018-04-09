using System.Threading.Tasks;

namespace Easynvest.BuildingBlocks.App.AggregateModel.TreasuryDirectAggregateModel
{
    public class ProcessItemIntoBasket : SellTreasuryDirectSteps
    {
        public ProcessItemIntoBasket(ISellTreasuryDirectStepRequest request)
            : base(request)
        {

        }

        public override async Task<SellTreasuryDirectStepResponse> Pull()
        {
            var marketId = (_request as ProcessItemIntoBasketRequest).MarketId;
            var customerId = (_request as ProcessItemIntoBasketRequest).CustomerId;
            var basketId = (_request as ProcessItemIntoBasketRequest).BasketId;
            var securityId = (_request as ProcessItemIntoBasketRequest).SecurityId;

            return await Task.FromResult<SellTreasuryDirectStepResponse>(new SellTreasuryDirectStepResponse
            {
                Id = "1",
                Description = "SUCCESS"
            });
        }
    }

    public class ProcessItemIntoBasketRequest : ISellTreasuryDirectStepRequest
    {
        public ProcessItemIntoBasketRequest(string customerId, string marketId, string basketId, string securityId, decimal quantity)
        {
            CustomerId = customerId;
            MarketId = marketId;
            BasketId = basketId;
            SecurityId = securityId;
            Quantity = quantity;
        }

        public string CustomerId { get; }
        public string MarketId { get; }
        public string BasketId { get; }
        public string SecurityId { get; }
        public decimal Quantity { get; }
    }
}
