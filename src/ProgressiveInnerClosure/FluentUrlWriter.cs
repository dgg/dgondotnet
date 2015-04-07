using System;
using System.Text;
using DgonDotNet.Blog.Samples.ProgressiveInnerClosure.ClosureMembers;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	public class FluentUrlWriter : IUrlWriter
	{
		private static readonly string _separator = "/";
		public string Write(Func<IStart, IEnd> url)
		{
			IEnd end = url(new Start(new NonEmptySegmentCollection(15)));
			StringBuilder sb = new StringBuilder();
			sb.Append(_separator);
			sb.Append(end.Segments.ToString(_separator));
			return sb.ToString();
		}
	}
}
