using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easynvest.BuildingBlocks.App.AggregateModel.TreasuryDirectAggregateModel
{
    public interface ITreasuryDirectRepository
    {
        Task PersistSellTreasuryDirect(IEnumerable<SellTreasuryDirect> sells);
    }
}
