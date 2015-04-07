namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure.ClosureMembers
{
	internal abstract class BaseArea : IEnd
	{
		private readonly NonEmptySegmentCollection _segments;

		protected BaseArea(NonEmptySegmentCollection segments)
		{
			_segments = segments;
		}

		public virtual NonEmptySegmentCollection Segments { get { return _segments; } }

		protected void AddSegment(string segment)
		{
			_segments.Append(segment);
		}
	}
}
