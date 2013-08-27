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

		public static IEnumerable<T> Delete<T>(this IEnumerable<T> deletables) where T : IClientDeletable
		{
			return deletables.EmptyIfNull()
				// ignore the ones deleted client-side
				.Where(i => !i.ClientDeleted);
		}
	}
}