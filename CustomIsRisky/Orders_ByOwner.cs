using System.Linq;
using Raven.Client.Indexes;

namespace CustomIsRisky
{
	public class Snapshots_ByOwner : AbstractIndexCreationTask<Order>
	{
		public Snapshots_ByOwner()
		{
			Map = orders => orders.Select(o => new
			{
				o.Owner
			});
		}
	}
}