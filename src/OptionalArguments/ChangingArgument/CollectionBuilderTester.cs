using NUnit.Framework;
using NUnit.Framework.Constraints;
using Testing.Commons.NUnit.Constraints;

namespace DgonDotNet.Blog.Samples.OptionalArguments.ChangingArgument
{
	[TestFixture]
	public class CollectionBuilderTester
	{
		[Test]
		public void WhenBuildingComplexCollectionOfCollections_OnlyOneOfTheCollectionsIsPopulated()
		{
			var subject = new CollectionBuilder();
			CollectionOfCollections result = subject.BuildWithComplexLogic();

			Assert.That(result, withMemberCount(two: 2));
		}

		private static Constraint withMemberCount(uint? one = null, uint? two = null, uint? three = null, uint? four = null)
		{
			return new LambdaPropertyConstraint<CollectionOfCollections>(b => b.CollectionOne, lengthOrEmpty(one)) &
				new LambdaPropertyConstraint<CollectionOfCollections>(b => b.CollectionTwo, lengthOrEmpty(two)) &
				new LambdaPropertyConstraint<CollectionOfCollections>(b => b.CollectionThree, lengthOrEmpty(three)) &
				new LambdaPropertyConstraint<CollectionOfCollections>(b => b.CollectionFour, lengthOrEmpty(four));
		}

		private static Constraint lengthOrEmpty(uint? length)
		{
			return length.HasValue ?
				Has.Length.EqualTo(length.Value) :
				(Constraint)Is.Empty;
		}
	}
}