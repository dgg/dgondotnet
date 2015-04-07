using System;
using System.Globalization;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure.ClosureMembers
{
	public interface IStart
	{
		IArea In(CultureInfo language);
		IArea In(string language);
	}

	internal class Start : BaseArea, IStart
	{
		public Start(NonEmptySegmentCollection segments) : base(segments) { }

		public IArea In(CultureInfo language)
		{
			AddSegment(language.Name);
			return new Area(Segments);
		}

		public IArea In(string language)
		{
			return In(CultureInfo.GetCultureInfo(language));
		}
	}
}