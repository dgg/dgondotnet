using System.Collections.Generic;
using System.Linq;
using DgonDotNet.Blog.Samples.DynamicCollections.Controllers;
using DgonDotNet.Blog.Samples.DynamicCollections.Domain;
using DgonDotNet.Blog.Samples.DynamicCollections.Views;

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
			return from.Select(t => new SortableThing(t)).ToArray();
		}
	}
}