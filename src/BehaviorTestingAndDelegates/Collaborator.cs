using System;
using System.Collections.Generic;

namespace DgonDotNet.Blog.Samples.BehaviorTestingAndDelegates
{
	public class Collaborator : ICollaborator
	{
		public IEnumerable<Something> Baz(Func<Something, bool> predicate)
		{
			// do something clever with predicate
			return new Something[0];
		}
	}
}
