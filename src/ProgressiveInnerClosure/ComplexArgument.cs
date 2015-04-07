namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	public class ComplexArgument
	{
		public ComplexArgument() : this(null) { }

		public ComplexArgument(string s1) : this(s1, new string[] {}) { }

		public ComplexArgument(string s1, string[] s2) : this(s1, s2, null) { }

		public ComplexArgument(string s1, string[] s2, string s3)
		{
			S1 = s1;
			S2 = s2;
			S3 = s3;
		}

		public string S1 { get; private set; }
		public string[] S2 { get; private set; }
		public string S3 { get; private set; }
	}
}