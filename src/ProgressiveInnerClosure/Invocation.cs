using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	public class Invocation
	{
		private readonly MethodInfo _method;
		private readonly object[] _expected;
		private readonly Func<IList<object[]>> _actual;

		public Invocation(MethodInfo method, object[] expected, Func<IList<object[]>> actual)
		{
			_method = method;
			_expected = expected;
			_actual = actual;
		}

		public string Actual()
		{
			return _method.Name + "(" + arguments(_actual().FirstOrDefault()) + ")";
		}

		public string Expected()
		{
			return _method.Name + "(" + arguments(_expected) + ")";
		}

		public string arguments(object[] arg)
		{
			return arg != null ?
				string.Join(", ", arg.Select(a => a != null ? a.ToString() : "null").ToArray()) :
				string.Empty;
		}
	}
}