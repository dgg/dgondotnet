namespace DgonDotNet.Blog.Samples.OptionalArguments.ChangingArgument
{
	public class CollectionBuilder
	{
		public CollectionOfCollections BuildWithComplexLogic()
		{
			return new CollectionOfCollections {
				CollectionOne = new string[0],
				CollectionTwo = new[] { "one", "two" },
				CollectionThree = new string[0],
				CollectionFour = new string[0],
			};
		}
	}
}