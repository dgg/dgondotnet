extern alias castle;

using System.Reflection;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	internal class ExpectationsSpy : castle::Castle.Core.Interceptor.IInterceptor
	{
		public object[] Arguments { get; private set;}
		public MethodInfo Method { get; private set; }

		public void Intercept(castle::Castle.Core.Interceptor.IInvocation invocation)
		{
			Method = invocation.Method;
			Arguments = invocation.Arguments;
		}
	}
}