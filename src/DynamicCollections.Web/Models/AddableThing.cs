using System.Collections.Generic;
using System.Linq;
using DgonDotNet.Blog.Samples.DynamicCollections.Domain;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Models
{
	public class AddableThing
	{
		public AddableThing() { }

		public AddableThing(Thing from)
		{
			Number = from.Number;
			Text = from.Text;
			IsEven = (from.Number % 2) == 0;
		}

		public string Text { get; set; }
		public int Number { get; set; }
		public bool IsEven { get; private set; }


		public static AddableThing[] FromThings(IEnumerable<Thing> from)
		{
			return from.Select((t, i) => new AddableThing(t)).ToArray();
		}
	}
}