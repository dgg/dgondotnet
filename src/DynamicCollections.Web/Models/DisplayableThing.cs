using System.Collections.Generic;
using System.Linq;
using DgonDotNet.Blog.Samples.DynamicCollections.Domain;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Models
{
	public class DisplayableThing
	{
		 public DisplayableThing() { }

		public DisplayableThing(Thing from)
		{
			Number = from.Number;
			Text = from.Text;
			IsEven = (from.Number % 2) == 0;
		}

		public string Text { get; set; }
		public int Number { get; set; }
		public bool IsEven { get; private set; }

		public static DisplayableThing[] FromThings(IEnumerable<Thing> from)
		{
			return from.EmptyIfNull().Select((t, i) => new DisplayableThing(t)).ToArray();
		}
	}
}