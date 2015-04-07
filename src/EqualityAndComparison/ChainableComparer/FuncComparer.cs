using System;
using System.Collections.Generic;

namespace DgonDotNet.Blog.Samples.EqualityAndComparison.ChainableComparer
{
	public class FuncComparer<T, K> : ChainableComparer<T>
	{
		private readonly Func<T, K> _keySelector;
		private readonly IComparer<K> _keyComparer;

		public FuncComparer(Func<T, K> keySelector) : this(keySelector, Direction.Ascending) { }

		public FuncComparer(Func<T, K> keySelector, Direction sortDirection)
			: this(keySelector, sortDirection, Comparer<K>.Default) { }

		public FuncComparer(Func<T, K> keySelector, Direction sortDirection, IComparer<K> keyComparer)
			: base(sortDirection)
		{
			_keySelector = keySelector;
			_keyComparer = keyComparer;
		}

		public override int DoCompare(T x, T y)
		{
			return _keyComparer.Compare(_keySelector.Invoke(x), _keySelector.Invoke(y));
		}

		public static Comparison<T> ConvertTo(Func<T, K> keySelector)
		{
			return new FuncComparer<T, K>(keySelector);
		}

		public static Comparison<T> ConvertTo(Func<T, K> keySelector, Direction direction)
		{
			return new FuncComparer<T, K>(keySelector, direction);
		}

		public static Comparison<T> ConvertTo(Func<T, K> keySelector, Direction direction, IComparer<K> keyComparer)
		{
			return new FuncComparer<T, K>(keySelector, direction, keyComparer);
		}

		public static implicit operator Comparison<T>(FuncComparer<T, K> comparer)
		{
			Comparison<T> comparison = comparer.Compare;
			return comparison;
		}
	}
}
