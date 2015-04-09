using System.Collections;
using System.Collections.Generic;

namespace Dgg.Anug.DbC.Domain.NoContract
{
	public class Basket : IEnumerable<WithContract.LineItem>
	{
		private readonly IList<WithContract.LineItem> _items;
		public Basket()
		{
			int carefullyMeasuredCapacity = 5;
			_items = new List<WithContract.LineItem>(carefullyMeasuredCapacity);
		}

		public IEnumerable<WithContract.LineItem> Items { get { return _items; } }

		public WithContract.Currency? Currency {get; private set;}
		public void Add(WithContract.LineItem item)
		{
			_items.Add(item);
			Currency = item.UnitPrice.Currency;
		}

		public void Add(params WithContract.LineItem[] items)
		{
			foreach (var item in items)
			{
				Add(item);
			}
		}

		public int Count { get { return _items.Count; } }
		
		public IEnumerator<WithContract.LineItem> GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Apply(IEnumerable<WithContract.Discount> discounts)
		{
			for (int i = 0; i < _items.Count; i++)
			{
				_items[i].Apply(discounts);
			}
		}
	}
}
