using System.Collections.Generic;
using System.Linq;
using DgonDotNet.Blog.Samples.DynamicCollections.Domain;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Models
{
	public static class ClientEditableExtensions
	{
		public static IEnumerable<T> Sort<T>(this IEnumerable<T> sortables) where T : IClientSortable
		{
			return sortables.EmptyIfNull()
				// sort by the number set cliet-side when re-ordering
				.OrderBy(i => i.ClientOrder);
		}
	}
}