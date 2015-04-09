using System.Collections.Generic;
using Dgg.Anug.DbC.Domain;
using Dgg.Anug.DbC.Domain.WithContract;
using NUnit.Framework;

namespace Dgg.Anug.DbC.Tests
{
	[TestFixture]
	public class DiscountCalculatorTester
	{

	}

	internal class DiscountCalculatorDouble : IDiscountCalculator
	{
		public IEnumerable<Discount> Calculate(IEnumerable<LineItem> items)
		{
			return new Discount[0];
		}
	}
}
