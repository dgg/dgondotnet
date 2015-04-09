using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Dgg.Anug.DbC.Domain.WithContract
{
	public class Basket : IEnumerable<LineItem>
	{
		private readonly IList<LineItem> _items;
		public Basket()
		{
			int carefullyMeasuredCapacity = 5;
			_items = new List<LineItem>(carefullyMeasuredCapacity);
		}

		public IEnumerable<LineItem> Items { get { return _items; } }

		public Currency? Currency { get; private set; }
		public void Add(LineItem item)
		{
			Contract.Requires(item != null);
			Contract.Requires(Currency.HasValue ? item.SameCurrency(Currency.Value) : true, "all items need to have the same currency");
			Contract.Ensures(Count == Contract.OldValue(Count) + 1);
			_items.Add(item);
			Currency = item.UnitPrice.Currency;
		}

		public void Add(params LineItem[] items)
		{
			Contract.Requires(items != null);
			Contract.Requires(Contract.ForAll(items, i => i != null));
			Contract.Ensures(Count == Contract.OldValue(Count) + items.Length);
			foreach (var item in items)
			{
				Add(item);
			}
		}

		public int Count { get { return _items.Count; } }

		public IEnumerator<LineItem> GetEnumerator()
		{
			Contract.Ensures(Contract.Result<IEnumerator<LineItem>>() != null);
			return _items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		[ContractInvariantMethod]
		private void invariants()
		{
			Contract.Invariant(_items != null);
		}

		public void Apply(IEnumerable<Discount> discounts)
		{
			Contract.Requires(discounts != null);
			// NOTE: cannot make it save the old value
			//Contract.Ensures(Contract.ForAll(Items, i => Contract.OldValue(i).TotalPrice >= i.TotalPrice));

			for (int i = 0; i < _items.Count; i++)
			{
				_items[i].Apply(discounts);
			}
		}
	}
}
