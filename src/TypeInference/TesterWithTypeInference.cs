using System;
using NUnit.Framework;

namespace DgonDotNet.Blog.Samples.TypeInference
{
	[TestFixture]
	public class TesterWithTypeInference
	{
		[Test]
		public void Do_GenericForTheRescue_RemovesDuplication()
		{
			var subject = AorB.OnlyA(3);

			bool wasExecuted = false;
			Func<ValueObject_A, string> executed = a =>
			{
				Assert.That(a.Value, Is.EqualTo(3));
				wasExecuted = true;
				return string.Empty;
			};

			subject.Do(executed, delegate(ValueObject_B b) { return notExecuted(b); });
			Assert.That(wasExecuted, Is.True);
		}

		[Test]
		public void Do_WithTypeInference_SlimAsItCanBe()
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

		private string notExecuted<T>(T aOrB)
		{
			Assert.Fail("must not execute");
			return string.Empty;
		}
	}
}