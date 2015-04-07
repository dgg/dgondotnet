using System;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure.ClosureMembers
{
	public interface IEntity
	{
		IEnd Find { get; }
		IEnd Op { get; }
	}

	internal class Entity : BaseArea, IEntity
	{
		public Entity(NonEmptySegmentCollection segments)
			: base(segments)
		{
			AddSegment("entity");
		}

		public Entity(NonEmptySegmentCollection segments, Guid id)
			: this(segments)
		{
			AddSegment(id.ToString());
		}

		public IEnd Find
		{
			get
			{
				AddSegment("find");
				return this;
			}
		}

		public IEnd Op
		{
			get
			{
				AddSegment("op");
				return this;
			}
		}
	}
}