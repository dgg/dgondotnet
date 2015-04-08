using NUnit.Framework.Constraints;

namespace DgonDotNet.Blog.Samples.ExpectedObjects.Support
{
	public static class Does
	{
		public static class Not
		{
			public static Constraint Match(object expected)
			{
				return new NotConstraint(new NotMatchingConstraint(expected));
			}
		}

		public static Constraint Match(object expected)
		{
			return new MatchingConstraint(expected);
		}
	}
}
