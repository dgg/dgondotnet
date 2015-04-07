extern alias castle;

using System;
using System.Collections.Generic;
using System.Text;
using DgonDotNet.Blog.Samples.ProgressiveInnerClosure.ClosureMembers;
using Rhino.Mocks;
using Rhino.Mocks.Exceptions;

using ProxyGenerator = castle::Castle.DynamicProxy.ProxyGenerator;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	public class UrlWriterDouble : IUrlWriter
	{
		private readonly IMockClosureMembers _stub;
		private readonly List<Invocation> _invocations;
		private readonly ExpectationsSpy _spy;
		private readonly IMockClosureMembers _proxy;
		public UrlWriterDouble()
		{
			_stub = MockRepository.GenerateStub<IMockClosureMembers>();
			_spy = new ExpectationsSpy();
			_proxy = new ProxyGenerator().CreateInterfaceProxyWithoutTarget<IMockClosureMembers>(_spy);
			_invocations = new List<Invocation>(10);
		}

		public string Write(Func<IStart, IEnd> url)
		{
			return url(_stub).Segments.ToString();
		}

		public void StubAll<T>(Function<IMockClosureMembers, T> f, string written)
		{
			_stub.Stub(f).Return((T)_stub);
			_stub.Stub(m => m.Segments).Return(new NonEmptySegmentCollection(1).Append(written));
		}

		public UrlWriterDouble Arrange<T>(Func<IMockClosureMembers, T> mockCall)
		{
			addInvocation(mockCall);

			_stub.Stub(m => mockCall(m)).Return((T)_stub);
			return this;
		}

		public UrlWriterDouble Arrange(Func<IMockClosureMembers, IEnd> mockCall, string written)
		{
			addInvocation(mockCall);

			var writable = MockRepository.GenerateStub<IEnd>();
			writable.Stub(w => w.Segments).Return(new NonEmptySegmentCollection().Append(written));
			_stub.Stub(m => mockCall(m)).Return(writable);
			return this;
		}

		public void Act(Action action)
		{
			try
			{
				action();
			}
			catch (NullReferenceException)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("\n\t\tExpected: url => url");
				foreach (var invocation in _invocations)
				{
					sb.Append(".");
					sb.Append(invocation.Expected());
				}
				sb.Append("\n\t\tActual: url => url");
				foreach (var invocation in _invocations)
				{
					sb.Append(".");
					sb.Append(invocation.Actual());
				}
				throw new ExpectationViolationException(sb.ToString());
			}
		}

		private void addInvocation<T>(Func<IMockClosureMembers, T> call)
		{
			call(_proxy);
			var expected = _spy.Arguments;
			Func<IList<object[]>> actual = () => _stub.GetArgumentsForCallsMadeOn(s => call(s));

			Invocation inv = new Invocation(_spy.Method, expected, actual);
			_invocations.Add(inv);
		}
	}
}

