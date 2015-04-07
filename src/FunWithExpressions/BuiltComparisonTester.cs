using System;
using NUnit.Framework;

namespace DgonDotNet.Blog.Samples.FunWithExpressions
{
	[TestFixture]
	public class BuiltComparisonTester
	{
		private static readonly Comparison<int> _canonical = (x, y) => x.CompareTo(y);
		private static readonly Comparison<int> _template = (x, y) => (x > y) ? 1 : ((x < y) ? -1 : 0);

		[Test]
		public void Canonical_Offers_BaselineBehavior()
		{
			Assert.That(_canonical(1, 2), Is.EqualTo(-1));
			Assert.That(_canonical(2, 1), Is.EqualTo(1));
			Assert.That(_canonical(1, 1), Is.EqualTo(0));
		}

		[Test]
		public void Template_SameBehavior_AsCanonical()
		{
			Assert.That(_template(1, 2), Is.EqualTo(-1));
			Assert.That(_template(2, 1), Is.EqualTo(1));
			Assert.That(_template(1, 1), Is.EqualTo(0));
		}

		[Test]
		public void Generated_SameBehavior_AsCanonical()
		{
			Comparison<int> generated = new ComparisonBuilder<int>().Comparison;
			Assert.That(generated(1, 2), Is.EqualTo(-1));
			Assert.That(generated(2, 1), Is.EqualTo(1));
			Assert.That(generated(1, 1), Is.EqualTo(0));
		}
	}
}
