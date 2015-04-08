using System;
using NUnit.Framework.Constraints;

namespace DgonDotNet.Blog.Samples.ExpectedObjects.Support
{
	public class MatchingConstraint : ExpectedConstraint
	{
		public MatchingConstraint(object expected) : base(expected) { }

		public override void WriteDescriptionTo(MessageWriter writer)
		{
			string results = _writer.GetFormattedResults();
			string resultWithLeadingAndWithoutTrailing = Environment.NewLine +
				results.Remove(results.Length - 2, 2);

			writer.Write(resultWithLeadingAndWithoutTrailing);
		}
	}
}
