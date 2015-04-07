namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure.ClosureMembers
{
	public interface IComplex
	{
		IS1 S1(string s1);
	}

	internal class Complex : BaseArea, IComplex
	{
		public Complex(NonEmptySegmentCollection segments) : base(segments)
		{
			AddSegment("complex");
		}

		public IS1 S1(string s1)
		{
			return new S1(Segments, s1);
		}
	}

	public interface  IS1 : IEnd
	{
		IS2 S2(string s2);
		IS2 S2(string s2, params string[] rest);
	}

	internal class S1 : BaseArea, IS1
	{
		public S1(NonEmptySegmentCollection segments, string s1) : base(segments)
		{
			AddSegment(s1);
		}

		public IS2 S2(string s2)
		{
			return new S2Impl(Segments, s2);
		}

		public IS2 S2(string s2, params string[] rest)
		{
			var impl = new S2Impl(Segments, s2);
			foreach (var s in rest)
			{
				impl.S2(s);
			}
			return impl;
		}
	}

	public interface  IS2 : IEnd
	{
		IS2 S2(string s2);
		IEnd S3(string s3);
	}
	internal  class S2Impl : BaseArea, IS2
	{
		public S2Impl(NonEmptySegmentCollection segments, string s2)
			: base(segments)
		{
			AddSegment(s2);
		}

		public IS2 S2(string s2)
		{
			AddSegment(s2);
			return this;
		}

		public IEnd S3(string s3)
		{
			AddSegment(s3);
			return this;
		}
	}

}