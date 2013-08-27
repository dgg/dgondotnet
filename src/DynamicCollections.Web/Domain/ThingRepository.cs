using System.Collections.Generic;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Domain
{
	public class ThingRepository : IThingRepository
	{
		private static readonly List<Thing> _things;

		static ThingRepository()
		{
			_things = new List<Thing>
			{
				new Thing{Number = 1, Text = "One"},
				new Thing{Number = 2, Text = "Two"},
				new Thing{Number = 3, Text = "Three"}
			};
		}

		public IEnumerable<Thing> Find()
		{
			return _things;
		}

		public void Save(IEnumerable<Thing> thingies)
		{
			_things.Clear();
			_things.AddRange(thingies);
		}
	}
}