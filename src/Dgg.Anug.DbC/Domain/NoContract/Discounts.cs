namespace Dgg.Anug.DbC.Domain.NoContract
{
	public abstract class Discount
	{
		public WithContract.ProductId Product { get; private set; }

		protected Discount(WithContract.ProductId product)
		{
			Product = product;
		}

		public virtual WithContract.Money Apply(WithContract.Money price)
		{
			return new WithContract.Money(applyOver(price.Amount), price.Currency);
		}

		protected virtual decimal applyOver(decimal oldAmount)
		{
			return oldAmount;
		}
	}

	public class NewAmountDiscount : Discount
	{
		private readonly decimal _newAmount;
		public decimal NewAmount { get { return _newAmount; } }

		public NewAmountDiscount(decimal newAmount, WithContract.ProductId product)
			: base(product)
		{
			_newAmount = newAmount;
		}

		protected override decimal applyOver(decimal oldAmount)
		{
			return NewAmount;
		}
	}

	public class AmountDiscount : Discount
	{
		private readonly decimal _discountedAmount;
		public decimal DiscountedAmount { get { return _discountedAmount; } }

		public AmountDiscount(decimal discountedAmount, WithContract.ProductId product)
			: base(product)
		{
			_discountedAmount = discountedAmount;
		}

		protected override decimal applyOver(decimal oldAmount)
		{
			return oldAmount - DiscountedAmount;
		}
	}

	public class PercentageDiscount : Discount
	{
		private readonly decimal _fraction;

		public PercentageDiscount(decimal fraction, WithContract.ProductId product)
			: base(product)
		{
			_fraction = fraction;
		}

		protected override decimal applyOver(decimal oldAmount)
		{
			return oldAmount - decimal.Multiply(oldAmount, _fraction);
		}
	}
}