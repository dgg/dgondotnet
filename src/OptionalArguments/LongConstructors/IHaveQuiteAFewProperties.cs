namespace DgonDotNet.Blog.Samples.OptionalArguments.LongConstructors
{
	public class IHaveQuiteAFewProperties
	{
		public int I1 { get; set; }
		public int I2 { get; set; }
		public string S { get; set; }
		public decimal D1 { get; set; }
		public decimal D2 { get; set; }

		public IHaveQuiteAFewProperties() { }

		public IHaveQuiteAFewProperties(int i1, int i2, string s, decimal d1, decimal d2)
		{
			I1 = i1;
			I2 = i2;
			S = s;
			D1 = d1;
			D2 = d2;
		}

		public static void LoosePropertyInitializers()
		{
			var subject = new IHaveQuiteAFewProperties
			{
				I1 = 1, I2 = 2,
				S = "something",
				// snaps! I forgot to set D1 to -3.5m,
				D2 = -4.3m
			};
		}

		public static void DescriptiveConstructors()
		{
			var subject = new IHaveQuiteAFewProperties(
				i1: 1, i2: 2,
				s: "something",
				d1: -3.5m, d2: -4.3m);
		}
	}
}
