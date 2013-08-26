using System.Collections.Generic;
using System.Linq;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Domain
{
	public static class SomeUsefulExtensions
	{
		public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> collection)
		{
			return collection ?? Enumerable.Empty<T>();
		}
	}
}