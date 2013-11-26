using System.Linq;
using Raven.Client.Indexes;

namespace CustomIsRisky.Custom
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
					o.Currency,
					Amount = o.Lines.Sum(l => l.Price.Amount)
				}
			});
		}
		public override string TransformerName { get { return "Custom_SnapshotTransformer"; }
		}
	}
}