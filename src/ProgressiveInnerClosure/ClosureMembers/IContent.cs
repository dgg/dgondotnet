namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure.ClosureMembers
{
	public interface IContent
	{
		IEnd X { get; }
	}

	internal class Content : BaseArea, IContent
	{
		public Content(NonEmptySegmentCollection segments) : base(segments)
		{
			AddSegment("content");
		}

		public IEnd X
		{
			get
			{
				AddSegment("x");
				return this;
			}
		}
	}
}