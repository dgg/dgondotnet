namespace DgonDotNet.Blog.Samples.TypeInference
{
	public struct ValueObject_B
	{
		public ValueObject_B(decimal b) : this()
		{
			Value = b;
		}

		public decimal Value { get; private set; }
	}
}