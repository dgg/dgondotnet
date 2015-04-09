using Dgg.Anug.DbC.Domain.WithContract;
using NUnit.Framework;

namespace Dgg.Anug.DbC.Tests
{
	[TestFixture]
	public class BasketTester
	{
		[Test]
		public void Apply_SomeDiscounts_ModifiesItems()
		{
			ProductId one = new ProductId("P-(11111)"), two = new ProductId("P-(22222)"), three = new ProductId("P-(33333)");
			Basket basket = new Basket
			{
				new LineItem(1, one, new Money(1, Currency.USD)),
				new LineItem(1, two, new Money(2, Currency.USD)),
				new LineItem(1, three, new Money(3, Currency.USD)),
			};

			var discounts = new Discount[] { new NewAmountDiscount(1, two), new AmountDiscount(2, three) };

			basket.Apply(discounts);

			Assert.That(basket.Items, Has
				.Some.Matches<LineItem>(i => i.Product.Equals(one) && i.UnitPrice.Equals(new Money(1, Currency.USD))).And
				.Some.Matches<LineItem>(i => i.Product.Equals(two) && i.UnitPrice.Equals(new Money(1, Currency.USD))).And
				.Some.Matches<LineItem>(i => i.Product.Equals(three) && i.UnitPrice.Equals(new Money(1, Currency.USD))));
		}
	}
}
