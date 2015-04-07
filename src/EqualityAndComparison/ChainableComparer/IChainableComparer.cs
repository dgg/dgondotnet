using System;
using System.Collections.Generic;

namespace DgonDotNet.Blog.Samples.EqualityAndComparison.ChainableComparer
{
	public interface IChainableComparer<T> : IComparer<T>
	{
		int DoCompare(T x, T y);
		IChainableComparer<T> Then(IChainableComparer<T> nextComparer);
		IChainableComparer<T> Then(Comparison<T> nextComparer);
		IChainableComparer<T> Then(Comparison<T> nextComparer, Direction sortDirection);
		IChainableComparer<T> Then<U>(Func<T, U> nextComparer);
		IChainableComparer<T> Then<U>(Func<T, U> nextComparer, Direction sortDirection);
		IChainableComparer<T> Then<U>(Func<T, U> nextComparer, Direction sortDirection, IComparer<U> keyComparer);
	}
}
