using System.Linq;
using Raven.Client.Indexes;

namespace CustomIsRisky
{
	public class SnapshotTransformer : AbstractTransformerCreationTask<Order>
	{
		public SnapshotTransformer()
		{
			TransformResults = orders => orders.Select(o => new
			{
				o.Number,
				o.Owner,
				o.Created,
				LineCount = o.Lines.Length,
				Total = new
				{
					currency = o.Currency,
					amount = o.Lines.Sum(l => l.Price.Amount)
				}
			});
		}
	}
}