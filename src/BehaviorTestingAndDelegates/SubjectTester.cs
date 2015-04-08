using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;

namespace DgonDotNet.Blog.Samples.BehaviorTestingAndDelegates
{
	[TestFixture]
	public class SubjectTester
	{
		private ICollaborator _collaborator;

		private ISubject initSubject()
		{
			_collaborator = MockRepository.GenerateStub<ICollaborator>();

			return new Subject(_collaborator);
		}

		[Test]
		public void FooMethod_CallsCollaboratorWithFooDelgate()
		{
			ISubject subject = initSubject();
			subject.FooMethod();

			Func<Something, bool> predicate = getPredicateArgument();
			Something satisfiesPredicate = new Something { Foo = 1, Bar = -1 };
			Assert.That(predicate(satisfiesPredicate), Is.True, "can only be true if Foo > 0, hence Foo is used in the delegate");
		}

		[Test]
		public void BarMethod_CallsCollaboratorWithBarDelgate()
		{
			ISubject subject = initSubject();

			subject.BarMethod();

			Func<Something, bool> predicate = getPredicateArgument();
			Something satisfiesPredicate = new Something { Foo = -1, Bar = 1 };
			Assert.That(predicate(satisfiesPredicate), Is.True, "can only be true if Bar > 0, hence Bar is used in the delegate");
		}

		private Func<Something, bool> getPredicateArgument()
		{
			int firstCall = 0, firstArgument = 0;

			IList<object[]> arguments = _collaborator.GetArgumentsForCallsMadeOn(
				c => c.Baz(Arg<Func<Something, bool>>.Is.Anything));

			return (Func<Something, bool>)arguments[firstCall][firstArgument];
		}
	}
}
