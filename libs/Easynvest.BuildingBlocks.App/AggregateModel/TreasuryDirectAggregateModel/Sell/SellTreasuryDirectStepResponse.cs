using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.App.AggregateModel.TreasuryDirectAggregateModel
{
    public class SellTreasuryDirectStepResponse
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public List<Notification> Notifications { get; set; }
        public string MessageResponse { get; set; }
    }
}
