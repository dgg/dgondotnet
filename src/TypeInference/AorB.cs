using System;

namespace DgonDotNet.Blog.Samples.TypeInference
{
	public class AorB
	{
		private ValueObject_A? A { get; set; }
		private ValueObject_B? B { get; set; }

		public AorB(int? a, decimal? b)
		{
			ensureOnlyOne(a, b);

			A = a.HasValue ? new ValueObject_A(a.Value) : default(ValueObject_A?);
			B = b.HasValue ? new ValueObject_B(b.Value) : default(ValueObject_B?);
		}

		private void ensureOnlyOne(int? a, decimal? b)
		{
			if ((a.HasValue && b.HasValue) || (!a.HasValue && !b.HasValue))
			{
				throw new NotSupportedException("Either A or B");
			}
		}

		public string Do(Func<ValueObject_A, string> actionWithA, Func<ValueObject_B, string> actionWithB)
		{
			return A.HasValue ? actionWithA(A.Value) : actionWithB(B.GetValueOrDefault());
		}

		public static AorB OnlyA(int a)
		{
			return new AorB(a, default(decimal?));
		}

		public static AorB OnlyB(decimal b)
		{
			return new AorB(default(int?), b);
		}
	}
}