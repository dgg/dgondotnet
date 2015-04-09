using System.Diagnostics.Contracts;

namespace Dgg.Anug.DbC.Domain.WithContract
{
	public abstract class Discount
	{
		public ProductId Product { get; private set; }

		protected Discount(ProductId product)
		{
			Product = product;
		}

		public virtual Money Apply(Money price)
		{
			Contract.Requires(price.Amount > 0m);
			Contract.Ensures(Contract.Result<Money>().Currency == price.Currency);
			Contract.Ensures(Contract.Result<Money>().Amount <= price.Amount);

			return new Money(applyOver(price.Amount), price.Currency);
		}

		protected virtual decimal applyOver(decimal oldAmount)
		{
			Contract.Requires(oldAmount > 0m);
			Contract.Ensures(Contract.Result<decimal>() <= oldAmount);
			return oldAmount;
		}
	}

	public class NewAmountDiscount : Discount
	{
		private readonly decimal _newAmount;
		public decimal NewAmount { get { return _newAmount; } }

		public NewAmountDiscount(decimal newAmount, ProductId product)
			: base(product)
		{
			Contract.Requires(newAmount >= 0m, "it's a discount, not another tax");
			_newAmount = newAmount;
		}

		protected override decimal applyOver(decimal oldAmount)
		{
			Contract.Requires(oldAmount >= NewAmount);
			return NewAmount;
		}
	}

	public class AmountDiscount : Discount
	{
		private readonly decimal _discountedAmount;
		public decimal DiscountedAmount { get { return _discountedAmount; } }

		public AmountDiscount(decimal discountedAmount, ProductId product)
			: base(product)
		{
			Contract.Requires(discountedAmount >= 0m, "it is a discount, not another tax");
			_discountedAmount = discountedAmount;
		}

		protected override decimal applyOver(decimal oldAmount)
		{
			Contract.Requires(oldAmount >= DiscountedAmount);

			return oldAmount - DiscountedAmount;
		}
	}

	public class PercentageDiscount : Discount
	{
		private readonly decimal _fraction;

		public PercentageDiscount(decimal fraction, ProductId product)
			: base(product)
		{
			Contract.Requires(fraction >= 0m, "only positive discounts");
			Contract.Requires(fraction <= 1m, "a fraction is a fraction is a fraction");

			_fraction = fraction;
		}

		protected override decimal applyOver(decimal oldAmount)
		{
			return oldAmount - decimal.Multiply(oldAmount, _fraction);
		}
	}
}