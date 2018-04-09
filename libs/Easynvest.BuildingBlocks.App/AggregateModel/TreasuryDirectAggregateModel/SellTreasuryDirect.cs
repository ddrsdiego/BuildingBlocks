using Easynvest.BuildingBlocks.App.AggregateModel.CustomerAggregateModel;
using System;
using System.Collections.Generic;

namespace Easynvest.BuildingBlocks.App.AggregateModel.TreasuryDirectAggregateModel
{
    public class SellTreasuryDirect
    {
        private IList<SellTreasuryDirectStepResponse> _steps;

        public SellTreasuryDirect(Customer customer,
                                  CustodyTreasuryDirect custodyTreasuryDirect,
                                  QuantitySellTreasuryDirect quantity)
        {
            Id = Guid.NewGuid().ToString("N");
            Customer = customer;
            CustodyTreasuryDirect = custodyTreasuryDirect;
            Quantity = quantity;
            _steps = new List<SellTreasuryDirectStepResponse>();
        }

        public string Id { get; }
        public Customer Customer { get; }
        public CustodyTreasuryDirect CustodyTreasuryDirect { get; }
        public QuantitySellTreasuryDirect Quantity { get; }
        public IEnumerable<SellTreasuryDirectStepResponse> SellTreasuryDirectSteps { get; }

        public void AddCompleteStep(SellTreasuryDirectStepResponse step)
        {
            _steps.Add(step);
        }
    }

    public class QuantitySellTreasuryDirect
    {
        public QuantitySellTreasuryDirect(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException(nameof(value));

            Value = value;
        }

        public decimal Value { get; }
    }
}
