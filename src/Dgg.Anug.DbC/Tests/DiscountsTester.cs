using System;
using System.Diagnostics.Contracts;
using Dgg.Anug.DbC.Domain;
using Dgg.Anug.DbC.Domain.WithContract;
using NUnit.Framework;

namespace Dgg.Anug.DbC.Tests
{
	[TestFixture, ContractVerification(false)]
	public class DiscountsTester
	{
		#region NewAmount

		[Test]
		public void NewAmount_LowerAmount_DiscountApplied()
		{
			Discount lowerAmount = new NewAmountDiscount(10m, ProductId.Any);
			Money discounted = lowerAmount.Apply(new Money(20m, Currency.DKK));

			Assert.That(discounted.Amount, Is.EqualTo(10m));
		}

		[Test]
		public void NewAmount_NegativeAmount_Exception()
		{
			Assert.That(() => new NewAmountDiscount(-1m, ProductId.Any),
				Throws.Exception
				.Matches<Exception>(e => e.GetType().Name.Equals("ContractException"))
				.With.Message.StringContaining("Precondition")
				.And.Message.StringContaining("tax"));
		}

		[Test]
		public void NewAmount_TooCheapToBeDiscounted_Exception()
		{
			Assert.That(() => new NewAmountDiscount(10m, ProductId.Any).Apply(new Money(5m, Currency.DKK)),
				Throws.Exception
				.Matches<Exception>(e => e.GetType().Name.Equals("ContractException"))
				.With.Message.StringContaining("Precondition")
				.And.Message.StringContaining("NewAmount"));
		}

		#endregion

		#region Amount

		[Test]
		public void AmountDifference_Positivedifference_DiscountApplied()
		{
			Discount positiveDifference = new AmountDiscount(10m, ProductId.Any);
			Money discounted = positiveDifference.Apply(new Money(20m, Currency.DKK));

			Assert.That(discounted.Amount, Is.EqualTo(10m));
		}

		[Test]
		public void AmountDifference_NegativeAmount_Exception()
		{
			Assert.That(() => new AmountDiscount(-1m, ProductId.Any),
				Throws.Exception
				.Matches<Exception>(e => e.GetType().Name.Equals("ContractException"))
				.With.Message.StringContaining("Precondition")
				.And.Message.StringContaining("tax"));
		}

		[Test]
		public void AmountDifference_TooCheapToBeDiscounted_Exception()
		{
			Assert.That(() => new AmountDiscount(10m, ProductId.Any).Apply(new Money(5m, Currency.DKK)),
				Throws.Exception
				.Matches<Exception>(e => e.GetType().Name.Equals("ContractException"))
				.With.Message.StringContaining("Precondition")
				.And.Message.StringContaining("DiscountedAmount"));
		}

		#endregion

		#region Percentage

		[Test]
		public void Percentage_HalfPrice_DiscountApplied()
		{
			Discount halfPrice = new PercentageDiscount(.5m, ProductId.Any);
			Money discounted = halfPrice.Apply(new Money(20m, Currency.DKK));

			Assert.That(discounted.Amount, Is.EqualTo(10m));
		}

		[Test]
		public void Percentage_NegativePercentage_Exception()
		{
			Assert.That(() => new PercentageDiscount(-0.5m, ProductId.Any),
				Throws.Exception
				.Matches<Exception>(e => e.GetType().Name.Equals("ContractException"))
				.With.Message.StringContaining("Precondition")
				.And.Message.StringContaining("positive"));
		}

		[Test]
		public void Percentage_WayTooCheap_Exception()
		{
			Assert.That(() => new PercentageDiscount(1.5m, ProductId.Any),
				Throws.Exception
				.Matches<Exception>(e => e.GetType().Name.Equals("ContractException"))
				.With.Message.StringContaining("Precondition")
				.And.Message.StringContaining("fraction"));
		}

		#endregion

		[Test]
		public void Prover_StrugglessWith_DecimalArithmetic()
		{
			var provenIncorrect = new Simplest(0, 4m);

			var unprovenButCorrect = new Simplest(2, 5m);

			var unprovenButIncorrect = new Simplest(2, 3m);
		}
	}

	class Simplest
	{
		public Simplest(int x, decimal d)
		{
			Contract.Requires(x > 1);
			Contract.Requires(d > 4m);
			I = x;
			D = d;
		}

		public int I { get; private set; }
		public decimal D { get; set; }
	}
}
