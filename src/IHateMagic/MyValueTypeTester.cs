using NUnit.Framework;

namespace DgonDotNet.Blog.Samples.IHateMagic
{
	[TestFixture]
	public class MyValueTypeTester
	{
		[Test]
		public void Equals_Null_False()
		{
			MyValueType subject = new MyValueType(1, 2);
			Assert.That(subject.Equals(null), Is.False);
		}
	}
}
