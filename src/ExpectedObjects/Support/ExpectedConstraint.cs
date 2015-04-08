using ExpectedObjects;
using NUnit.Framework.Constraints;

namespace DgonDotNet.Blog.Samples.ExpectedObjects.Support
{
	public abstract class ExpectedConstraint : Constraint
	{
		protected readonly ExpectedObject _expected;
		protected readonly IWriter _writer;

		protected ExpectedConstraint(object expected)
		{
			_writer = new ShouldWriter();
			_expected = expected.ToExpectedObject().Configure(ctx =>
			{
				ctx.IgnoreTypes();
				ctx.SetWriter(_writer);
			});
		}

		public override bool Matches(object current)
		{
			actual = current;
			return _expected.Equals(actual);
		}
	}
}
