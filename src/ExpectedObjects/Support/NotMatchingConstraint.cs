using NUnit.Framework.Constraints;

namespace DgonDotNet.Blog.Samples.ExpectedObjects.Support
{
	public class NotMatchingConstraint : ExpectedConstraint
	{
		public NotMatchingConstraint(object expected) : base(expected) { }

		public override void WriteDescriptionTo(MessageWriter writer)
		{
			writer.Write("matching ");
			writer.WriteValue(_expected);
		}
	}
}
