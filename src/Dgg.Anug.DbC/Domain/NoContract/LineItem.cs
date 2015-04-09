using System.Collections.Generic;
using System.Linq;

namespace Dgg.Anug.DbC.Domain.NoContract
{
	public class LineItem
	{
		public LineItem(int quantity, WithContract.ProductId product, WithContract.Money unitPrice)
		{
			Quantity = quantity;
			Product = product;
			UnitPrice = unitPrice;

			TotalPrice = calculateTotal();
		}

		private WithContract.Money calculateTotal()
		{
			return UnitPrice * Quantity;
		}

		public int Quantity { get; private set; }
		public WithContract.ProductId Product { get; set; }
		public WithContract.Money UnitPrice { get; private set; }

		public bool SameCurrency(LineItem item)
		{
			return UnitPrice.SameCurrency(item.UnitPrice);
		}

		public bool SameCurrency(WithContract.Currency other)
		{
			return other == UnitPrice.Currency;
		}

		public WithContract.Money TotalPrice { get; private set; }

		public override string ToString()
		{
			return Quantity + "# " + Product + " @ " + UnitPrice;
		}

		public void Apply(IEnumerable<Discount> discounts)
		{
			foreach (var discount in discounts.Where(d => d.Product.Equals(Product)))
			{
				UnitPrice = discount.Apply(UnitPrice);
				TotalPrice = calculateTotal();
			}
		}
	}
}
