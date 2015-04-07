using System;
using DgonDotNet.Blog.Samples.ProgressiveInnerClosure.ClosureMembers;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	public interface IUrlWriter
	{
		string Write(Func<IStart, IEnd> url);
	}
}