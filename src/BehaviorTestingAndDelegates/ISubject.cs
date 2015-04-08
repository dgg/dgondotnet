using System.Collections.Generic;

namespace DgonDotNet.Blog.Samples.BehaviorTestingAndDelegates
{
	public interface ISubject
	{
		IEnumerable<Something> FooMethod();
		IEnumerable<Something> BarMethod();
	}
}