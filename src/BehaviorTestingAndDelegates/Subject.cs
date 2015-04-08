using System.Collections.Generic;

namespace DgonDotNet.Blog.Samples.BehaviorTestingAndDelegates
{
	public class Subject : ISubject
	{
		private readonly ICollaborator _collaborator;

		public Subject(ICollaborator collaborator)
		{
			_collaborator = collaborator;
		}

		public IEnumerable<Something> FooMethod()
		{
			return _collaborator.Baz(s => s.Foo > 0);
		}

		public IEnumerable<Something> BarMethod()
		{
			return _collaborator.Baz(s => s.Bar > 0);
		}
	}
}
