using System;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure.ClosureMembers
{
	public interface IArea
	{
		IContent Content();
		IEntity Entity();
		IEnd Entity(Guid id);
		IComplex Complex();
	}

	internal class Area : BaseArea, IArea
	{
		public Area(NonEmptySegmentCollection segments) : base(segments) { }


		public IContent Content()
		{
			return new Content(Segments);
		}

		public IEntity Entity()
		{
			return new Entity(Segments);
		}

		public IEnd Entity(Guid id)
		{
			return new Entity(Segments, id);
		}

		public IComplex Complex()
		{
			return new Complex(Segments);
		}
	}
}