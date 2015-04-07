using System;
using System.Collections;
using System.Collections.Generic;

namespace DgonDotNet.Blog.Samples.EqualityAndComparison.Subjects
{
	public class MyReferenceType : IEquatable<MyReferenceType>, IComparable, IComparable<MyReferenceType>
	{
		public int Property1 { get; private set; }
		public int Property2 { get; private set; }
		public int Property3 { get; private set; }
		public int Property4 { get; private set; }
		public int Property5 { get; private set; }
		public int Property6 { get; private set; }

		public MyReferenceType(int property1, int property2, int property3, int property4, int property5, int property6)
		{
			Property1 = property1;
			Property2 = property2;
			Property3 = property3;
			Property4 = property4;
			Property5 = property5;
			Property6 = property6;
		}

		#region Equality

		public bool Equals(MyReferenceType obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.Property2 == Property2;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(MyReferenceType)) return false;
			return ((MyReferenceType)obj).Property1.Equals(Property1);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return Property3.GetHashCode();
			}
		}

		public static bool operator ==(MyReferenceType left, MyReferenceType right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(MyReferenceType left, MyReferenceType right)
		{
			return !Equals(left, right);
		}

		#endregion

		#region Comparison

		public int CompareTo(object obj)
		{
			if (!(obj is MyReferenceType))
			{
				throw new ArgumentException("obj", string.Format("The object to compare must be of type {0}.", typeof(MyReferenceType).Name));
			}
			return Property1.CompareTo(((MyReferenceType)obj).Property1);
		}

		public int CompareTo(MyReferenceType other)
		{
			if (other == null)
			{
				return 1;
			}
			return Property2.CompareTo(other.Property2);
		}

		public static bool operator <(MyReferenceType leftHandValue, MyReferenceType rightHandValue)
		{
			return leftHandValue.CompareTo(rightHandValue) < 0;
		}
		public static bool operator >(MyReferenceType leftHandValue, MyReferenceType rightHandValue)
		{
			return leftHandValue.CompareTo(rightHandValue) > 0;
		}
		public static bool operator <=(MyReferenceType leftHandValue, MyReferenceType rightHandValue)
		{
			return leftHandValue.CompareTo(rightHandValue) <= 0;
		}
		public static bool operator >=(MyReferenceType leftHandValue, MyReferenceType rightHandValue)
		{
			return leftHandValue.CompareTo(rightHandValue) >= 0;
		}

		#endregion

		public override string ToString()
		{
			return string.Format("{0} {1} {2} {3} {4} {5}", Property1, Property2, Property3, Property4, Property5, Property6);
		}

		public class Helper : IComparer, IComparer<MyReferenceType>, IEqualityComparer, IEqualityComparer<MyReferenceType>
		{
			public int Compare(object x, object y)
			{
				if ((x == null) && (y == null)) return 0;
				if (x == null) return -1;
				if (y == null) return 1;
				return ((MyReferenceType)x).Property4.CompareTo(((MyReferenceType)y).Property4);
			}

			public Comparison<MyReferenceType> GetComparison()
			{
				return (v1, v2) => Compare(v1, v2);
			}

			public int Compare(MyReferenceType x, MyReferenceType y)
			{
				if ((x == null) && (y == null)) return 0;
				if (x == null) return -1;
				if (y == null) return 1;
				return x.Property5.CompareTo(y.Property5);
			}

			public bool Equals(MyReferenceType x, MyReferenceType y)
			{
				if (x == null && y == null) return true;
				if (x != null && y != null) return x.Property5.Equals(y.Property5);
				return false;
			}

			public int GetHashCode(MyReferenceType obj)
			{
				if (obj == null) return 0;
				return obj.Property6;
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (ReferenceEquals(null, x) || ReferenceEquals(null, y)) return false;
				if (ReferenceEquals(x, y)) return true;
				if (x.GetType() != typeof(MyReferenceType) || y.GetType() != typeof(MyReferenceType)) return false;
				return ((MyReferenceType)x).Property4.Equals(((MyReferenceType)y).Property4);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				MyReferenceType typed = obj as MyReferenceType;
				if (typed == null) return 0;
				return typed.Property6;
			}
		}
	}
}
