using System;

namespace DgonDotNet.Blog.Samples.IHateMagic
{
	public struct MyValueType : IEquatable<MyValueType>
	{
		public static readonly char Tokenizer = 'x';
		public MyValueType(int property1, int property2) : this()
		{
			Property1 = property1;
			Property2 = property2;
		}

		public int Property1 { get; private set; }
		public int Property2 { get; private set; }

		public bool Equals(MyValueType other)
		{
			return other.Property1 == Property1 && other.Property2 == Property2;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (obj.GetType() != typeof (MyValueType)) return false;
			return Equals((MyValueType) obj);
		}

		public override int GetHashCode()
		{
			unchecked { return (Property1 * 397) ^ Property2; }
		}

		public override string ToString()
		{
			return string.Concat(Property1, Tokenizer, Property2);
		}

		public static MyValueType Parse(string s)
		{
			// defensive programming skipped
			string[] split = s.Split(new[] { Tokenizer }, StringSplitOptions.RemoveEmptyEntries);
			return new MyValueType(int.Parse(split[0]), int.Parse(split[1]));
		}

		// change to explicit for the test to pass
		public static implicit operator MyValueType(string s)
		{
			return Parse(s);
		}
	}
}