using System.Collections.Generic;
using System.Linq;
using DgonDotNet.Blog.Samples.DynamicCollections.Domain;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Models
{
	public class DeletableThing : IClientDeletable
	{
		public string Text { get; set; }
		public int Number { get; set; }
		public bool IsEven { get; private set; }
		public bool ClientDeleted { get; set; }

		public DeletableThing() { }

		public DeletableThing(Thing from)
		{
			Number = from.Number;
			Text = from.Text;
			IsEven = (from.Number % 2) == 0;
		}

		public static DeletableThing[] FromThings(IEnumerable<Thing> from)
		{
			return from.Select((t, i) =>
				new DeletableThing(t) { ClientDeleted = false })
				.ToArray();
		}

		public Thing ToThing()
		{
			return new Thing { Number = Number, Text = Text };
		}

		public static IEnumerable<Thing> ToThings(DeletableThing[] from)
		{
			return from
				.Delete()
				.Select(st => st.ToThing());
		}
	}
}