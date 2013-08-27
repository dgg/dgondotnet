using System.Collections.Generic;
using System.Linq;
using DgonDotNet.Blog.Samples.DynamicCollections.Domain;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Models
{
	public class SortableThing : IClientSortable
	{
		public string Text { get; set; }
		public int Number { get; set; }
		public bool IsEven { get; private set; }
		public int ClientOrder { get; set; }

		public SortableThing() { }

		public SortableThing(Thing from)
		{
			Number = from.Number;
			Text = from.Text;
			IsEven = (from.Number % 2) == 0;
		}

		public static SortableThing[] FromThings(IEnumerable<Thing> from)
		{
			return from.Select((t, i) => 
				new SortableThing(t){ ClientOrder = i})
				.ToArray();
		}

		public Thing ToThing()
		{
			return new Thing { Number = Number, Text = Text };
		}

		public static IEnumerable<Thing> ToThings(SortableThing[] from)
		{
			return from
				.Sort()
				.Select(st => st.ToThing());
		}
	}
}