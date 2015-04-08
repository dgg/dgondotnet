namespace DgonDotNet.Blog.Samples.TypeInference
{
	public struct ValueObject_A
	{
		public ValueObject_A(int a) : this()
		{
			Value = a;
		}

		public int Value { get; private set; }
	}
}