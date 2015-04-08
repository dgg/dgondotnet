using System;
using NUnit.Framework;

namespace DgonDotNet.Blog.Samples.TypeInference
{
	[TestFixture]
	public class TesterWithoutTypeInference
	{
		[Test]
		public void Do_UseAnonymousMethods_ABitNoisy()
		{
			var subject = AorB.OnlyA(3);

			Func<ValueObject_B, string> notExecuted = b =>
			{
				Assert.Fail("must not execute");
				return string.Empty;
			};

			bool wasExecuted = false;
			Func<ValueObject_A, string> executed = a =>
			{
				Assert.That(a.Value, Is.EqualTo(3));
				wasExecuted = true;
				return string.Empty;
			};

			subject.Do(executed, notExecuted);
			Assert.That(wasExecuted, Is.True);
		}

		[Test]
		public void Do_UseMethodForNotExecutedFunc_LeadsToDuplication()
		{
			var subject = AorB.OnlyB(3.5m);

			bool wasExecuted = false;
			Func<ValueObject_B, string> executed = a =>
			{
				Assert.That(a.Value, Is.EqualTo(3.5m));
				wasExecuted = true;
				return string.Empty;
			};

			subject.Do(notExecuted, executed);
			Assert.That(wasExecuted, Is.True);
		}

		private string notExecuted(ValueObject_A a)
		{
			Assert.Fail("must not execute");
			return string.Empty;
		}
		// same old, same old
		private string notExecuted(ValueObject_B b)
		{
			Assert.Fail("must not execute");
			return string.Empty;
		}
	}
}
