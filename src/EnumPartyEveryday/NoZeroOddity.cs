using System;
using NUnit.Framework;

namespace DgonDotNet.Blog.Samples.EnumPartyEveryday
{
	[TestFixture]
	public class NoZeroOddity
	{
		public enum NonZero
		{
			One = 1,
			Two = 2
		}

		[Test]
		public void DefaultValue_NotDefined()
		{
			Assert.That(Enum.IsDefined(typeof(NonZero), default(NonZero)), Is.False);
		}
	}
}
