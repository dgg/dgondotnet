using System.Linq;
using NMoneys;
using Raven.Client.Indexes;

namespace CustomIsRisky.Naive
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
				Total = Money.Total(o.Lines.Select(l => l.Price))
			});
		}
		public override string TransformerName { get { return "Naive_SnapshotTransformer"; } }
	}
}