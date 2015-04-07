using System;
using System.Collections.Generic;

namespace DgonDotNet.Blog.Samples.EqualityAndComparison.ChainableComparer
{
	public abstract class ChainableComparer<T> : IChainableComparer<T>
	{
		private IChainableComparer<T> _nextComparer;
		private readonly Direction _direction;
		public Direction SortDirection { get { return _direction; } }
		public abstract int DoCompare(T x, T y);

		#region Factory Methods

		public static IChainableComparer<T> By(Comparison<T> next)
		{
			return new ComparisonComparer<T>(next);
		}

		public static IChainableComparer<T> By(Comparison<T> next, Direction sortDirection)
		{
			return new ComparisonComparer<T>(next, sortDirection);
		}

		public static IChainableComparer<T> By<K>(Func<T, K> keySelector)
		{
			return new FuncComparer<T, K>(keySelector);
		}

		public static IChainableComparer<T> By<K>(Func<T, K> keySelector, Direction sortDirection)
		{
			return new FuncComparer<T, K>(keySelector, sortDirection);
		}

		public static IChainableComparer<T> By<K>(Func<T, K> keySelector, Direction sortDirection, IComparer<K> keyComparer)
		{
			return new FuncComparer<T, K>(keySelector, sortDirection, keyComparer);
		}

		#endregion

		protected ChainableComparer() : this(Direction.Ascending) { }

		protected ChainableComparer(Direction sortDirection)
		{
			_direction = sortDirection;
		}

		public IChainableComparer<T> Then(IChainableComparer<T> nextComparer)
		{
			_nextComparer = nextComparer;
			return this;
		}

		public IChainableComparer<T> Then(Comparison<T> next)
		{
			_nextComparer = new ComparisonComparer<T>(next);
			return this;
		}

		public IChainableComparer<T> Then(Comparison<T> next, Direction sortDirection)
		{
			_nextComparer = new ComparisonComparer<T>(next, sortDirection);
			return this;
		}

		public IChainableComparer<T> Then<U>(Func<T, U> keySelector)
		{
			_nextComparer = new FuncComparer<T, U>(keySelector);
			return this;
		}

		public IChainableComparer<T> Then<U>(Func<T, U> keySelector, Direction sortDirection)
		{
			_nextComparer = new FuncComparer<T, U>(keySelector, sortDirection);
			return this;
		}

		public IChainableComparer<T> Then<U>(Func<T, U> keySelector, Direction sortDirection, IComparer<U> keyComparer)
		{
			_nextComparer = new FuncComparer<T, U>(keySelector, sortDirection, keyComparer);
			return this;
		}

		public int Compare(T x, T y)
		{
			int result = DoCompare(x, y);
			if (needsToEvaluateNext(result)) result = _nextComparer.Compare(x, y);

			if (_direction == Direction.Descending) invert(ref result);

			return result;
		}

		private bool needsToEvaluateNext(int ret)
		{
			return ret == 0 && _nextComparer != null;
		}

		private static void invert(ref int result)
		{
			result *= -1;
		}
	}
}
