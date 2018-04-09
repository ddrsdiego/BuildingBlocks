using System.Threading.Tasks;

namespace Easynvest.BuildingBlocks.App.AggregateModel.TreasuryDirectAggregateModel
{
    public class ProcessSellTreasuryDirect : SellTreasuryDirectSteps
    {
        public ProcessSellTreasuryDirect(ISellTreasuryDirectStepRequest request)
            : base(request)
        {

        }

        public override async Task<SellTreasuryDirectStepResponse> Pull()
        {
            var marketId = (_request as ProcessSellTreasuryDirectResquest).MarketId;
            var customerId = (_request as ProcessSellTreasuryDirectResquest).CustomerId;
            var basketId = (_request as ProcessSellTreasuryDirectResquest).BasketId;
            var securityId = (_request as ProcessSellTreasuryDirectResquest).SecurityId;

            return await Task.FromResult<SellTreasuryDirectStepResponse>(new SellTreasuryDirectStepResponse
            {
                Id = "1",
                Description = "SUCCESS"
            });
        }
    }

    public class ProcessSellTreasuryDirectResquest : ISellTreasuryDirectStepRequest
    {
        public ProcessSellTreasuryDirectResquest(string customerId, string marketId, string basketId, string securityId, decimal quantity)
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
