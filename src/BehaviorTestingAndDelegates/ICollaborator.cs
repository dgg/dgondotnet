using System;
using System.Collections.Generic;

namespace DgonDotNet.Blog.Samples.BehaviorTestingAndDelegates
{
	public interface ICollaborator
	{
		IEnumerable<Something> Baz(Func<Something, bool> predicate);
	}
}