using System;
using System.Linq.Expressions;

namespace DgonDotNet.Blog.Samples.FunWithExpressions
{
	public class ComparisonBuilder<T>
	{
		public ComparisonBuilder()
		{
			Type t = typeof(T), @int = typeof(int);
			ParameterExpression x = Expression.Parameter(t, "x"), y = Expression.Parameter(t, "y");

			Expression<Comparison<T>> expr = Expression.Lambda<Comparison<T>>(
				Expression.Condition(
					Expression.GreaterThan(x, y),
					Expression.Constant(1, @int),
					Expression.Condition(
						Expression.LessThan(x, y),
						Expression.Constant(-1, @int),
						Expression.Constant(0, @int)
						)
					),
				x, y);
			Comparison = expr.Compile();
		}

		public Comparison<T> Comparison { get; private set; }
	}
}
