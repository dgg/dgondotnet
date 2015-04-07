using System;

namespace DgonDotNet.Blog.Samples.EqualityAndComparison.ChainableComparer
{
	public class ComparisonComparer<T> : ChainableComparer<T>
	{
		private readonly Comparison<T> _comparison;

		public ComparisonComparer(Comparison<T> comparison) :
			this(comparison, Direction.Ascending) { }

		public ComparisonComparer(Comparison<T> comparison, Direction sortDirection)
			: base(sortDirection)
		{
			_comparison = comparison;
		}

		public override int DoCompare(T x, T y)
		{
			return _comparison(x, y);
		}

		public static implicit operator Comparison<T>(ComparisonComparer<T> comparer)
		{
			Comparison<T> comparison = comparer.Compare;
			return comparison;
		}
	}
}
