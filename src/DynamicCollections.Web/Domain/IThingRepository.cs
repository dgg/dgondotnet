using System.Collections.Generic;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Domain
{
	public interface IThingRepository
	{
		IEnumerable<Thing> Find();
	}
}