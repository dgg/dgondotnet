using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Dgg.Anug.DbC.Domain.WithContract
{
	[Pure]
	public class LineItem
	{
		public LineItem(int quantity, ProductId product, Money unitPrice)
		{
			Contract.Requires(quantity > 0);
			Contract.Ensures(Quantity == quantity);
			Contract.Ensures(Quantity > 0);
			Contract.Ensures(Product == product);
			Contract.Ensures(UnitPrice == unitPrice);

			Quantity = quantity;
			Product = product;
			UnitPrice = unitPrice;

			TotalPrice = calculateTotal();
		}

		private Money calculateTotal()
		{
			Contract.Requires(Quantity > 0);
			return UnitPrice * Quantity;
		}

		[ContractInvariantMethod]
		private void totalInvariant()
		{
			Contract.Invariant(!UnitPrice.IsZero, "we hate free things");
			Contract.Invariant(TotalPrice >= UnitPrice);
		}

		public int Quantity { get; private set; }
		public ProductId Product { get; set; }
		public Money UnitPrice { get; private set; }

		public bool SameCurrency(LineItem item)
		{
			Contract.Requires(item != null);
			return UnitPrice.SameCurrency(item.UnitPrice);
		}

		public bool SameCurrency(Currency other)
		{
			return other == UnitPrice.Currency;
		}

		public Money TotalPrice { get; private set; }

		public override string ToString()
		{
			Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
			return Quantity + "# " + Product + " @ " + UnitPrice;
		}

		public void Apply(IEnumerable<Discount> discounts)
		{
			Contract.Requires(discounts != null);
			foreach (var discount in discounts.Where(d => d.Product.Equals(Product)))
			{
				UnitPrice = discount.Apply(UnitPrice);
				TotalPrice = calculateTotal();
			}
		}
	}
}
