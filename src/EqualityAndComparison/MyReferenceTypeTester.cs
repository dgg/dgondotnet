using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using DgonDotNet.Blog.Samples.EqualityAndComparison.Subjects;
using NUnit.Framework;

namespace DgonDotNet.Blog.Samples.EqualityAndComparison
{
	[TestFixture]
	public class MyReferenceTypeTester
	{
		private static string toString(IEnumerable a)
		{
			string result = string.Empty;
			foreach (var t in a)
			{
				result += t + ",";
			}
			return result.TrimEnd(',');
		}

		#region ArrayList.Sort

		[Test]
		public void ArrayList_Sort_UsesIComparable_P1()
		{
			ArrayList a = new ArrayList { new MyReferenceType(2, 1, 3, 0, 0, 0), new MyReferenceType(1, 2, 3, 0, 0, 0) };
			a.Sort();
			Assert.That(toString(a), Is.EqualTo("1 2 3 0 0 0,2 1 3 0 0 0"));
		}

		[Test]
		public void ArrayList_Sort_IComparer_P4()
		{
			ArrayList a = new ArrayList { new MyReferenceType(0, 0, 0, 2, 1, 3), new MyReferenceType(0, 0, 0, 1, 2, 3) };
			a.Sort(new MyReferenceType.Helper());
			Assert.That(toString(a), Is.EqualTo("0 0 0 1 2 3,0 0 0 2 1 3"));
		}

		#endregion

		#region ArrayList.IndexOf

		[Test]
		public void ArrayList_IndexOf_UsesEquals_P1()
		{
			ArrayList a = new ArrayList { new MyReferenceType(2, 1, 3, 0, 0, 0), new MyReferenceType(1, 2, 3, 0, 0, 0) };
			Assert.That(a.IndexOf(new MyReferenceType(1, 0, 0, 0, 0, 0)), Is.EqualTo(1));
		}

		#endregion

		#region Array.Sort

		[Test]
		public void Array_Sort_Object_UsesIComparable_P1()
		{
			object[] a = new object[] { new MyReferenceType(2, 1, 3, 0, 0, 0), new MyReferenceType(1, 2, 3, 0, 0, 0) };
			Array.Sort(a);
			Assert.That(toString(a), Is.EqualTo("1 2 3 0 0 0,2 1 3 0 0 0"));
		}

		[Test]
		public void Array_Sort_NonGeneric_UsesIComparable_P1()
		{
			MyReferenceType[] a = new[] { new MyReferenceType(2, 1, 3, 0, 0, 0), new MyReferenceType(1, 2, 3, 0, 0, 0) };
			// calls the non-generic version
			Array aa = a;
			Array.Sort(aa);
			Assert.That(toString(a), Is.EqualTo("1 2 3 0 0 0,2 1 3 0 0 0"));
		}

		[Test]
		public void Array_Sort_Generic_UsesIComparableT_P2()
		{
			MyReferenceType[] a = new[] { new MyReferenceType(1, 2, 3, 0, 0, 0), new MyReferenceType(2, 1, 3, 0, 0, 0) };
			Array.Sort(a);
			Assert.That(toString(a), Is.EqualTo("2 1 3 0 0 0,1 2 3 0 0 0"));
		}

		[Test]
		public void Array_Sort_NonGeneric_UsesIComparer_P4()
		{
			MyReferenceType[] a = new[] { new MyReferenceType(0, 0, 0, 4, 3, 5), new MyReferenceType(0, 0, 0, 3, 4, 5) };
			// calls the non-generic version
			Array aa = a;
			Array.Sort(aa, new MyReferenceType.Helper());
			Assert.That(toString(a), Is.EqualTo("0 0 0 3 4 5,0 0 0 4 3 5"));
		}

		[Test]
		public void Array_Sort_Generic_UsesIComparerT_P5()
		{
			MyReferenceType[] a = new[] { new MyReferenceType(0, 0, 0, 3, 4, 5), new MyReferenceType(0, 0, 0, 4, 3, 5) };
			Array.Sort(a, new MyReferenceType.Helper());
			Assert.That(toString(a), Is.EqualTo("0 0 0 4 3 5,0 0 0 3 4 5"));
		}

		[Test]
		public void Array_Sort_Generic_UsesComparisonT_P5()
		{
			MyReferenceType[] a = new[] { new MyReferenceType(0, 0, 0, 3, 4, 5), new MyReferenceType(0, 0, 0, 4, 3, 5) };
			Array.Sort(a, new MyReferenceType.Helper().GetComparison());
			Assert.That(toString(a), Is.EqualTo("0 0 0 4 3 5,0 0 0 3 4 5"));
		}

		#endregion

		#region Array.IndexOf

		[Test]
		public void Array_IndexOf_NonGeneric_UsesEquals_P1()
		{
			MyReferenceType[] a = new[] { new MyReferenceType(2, 1, 3, 0, 0, 0), new MyReferenceType(1, 2, 3, 0, 0, 0) };
			// calls the non-generic version
			Array aa = a;
			Assert.That(Array.IndexOf(aa, new MyReferenceType(1, 1, 1, 0, 0, 0)), Is.EqualTo(1));
		}

		[Test]
		public void Array_IndexOf_Generic_UsesEqualsT_P2()
		{
			MyReferenceType[] a = new[] { new MyReferenceType(1, 2, 3, 0, 0, 0), new MyReferenceType(2, 1, 3, 0, 0, 0) };
			Assert.That(Array.IndexOf(a, new MyReferenceType(1, 1, 1, 0, 0, 0)), Is.EqualTo(1));
			
		}

		#endregion

		#region List.Sort

		[Test]
		public void List_Sort_UsesIComparableT_P2()
		{
			var a = new List<MyReferenceType> { new MyReferenceType(1, 2, 3, 0, 0, 0), new MyReferenceType(2, 1, 3, 0, 0, 0) };
			a.Sort();
			Assert.That(toString(a), Is.EqualTo("2 1 3 0 0 0,1 2 3 0 0 0"));
		}
		[Test]
		public void List_Sort_IComparerT_P5()
		{
			var a = new List<MyReferenceType> { new MyReferenceType(0, 0, 0, 3, 4, 5), new MyReferenceType(0, 0, 0, 4, 3, 5) };
			a.Sort(new MyReferenceType.Helper());
			Assert.That(toString(a), Is.EqualTo("0 0 0 4 3 5,0 0 0 3 4 5"));
		}

		[Test]
		public void List_Sort_ComparisonT_P5()
		{
			List<MyReferenceType> a = new List<MyReferenceType> { new MyReferenceType(0, 0, 0, 3, 4, 5), new MyReferenceType(0, 0, 0, 4, 3, 5) };
			a.Sort(new MyReferenceType.Helper().GetComparison());
			Assert.That(toString(a), Is.EqualTo("0 0 0 4 3 5,0 0 0 3 4 5"));
		}

		#endregion

		#region List.IndexOf

		[Test]
		public void List_IndexOf_UsesEqualsT_P2()
		{
			List<MyReferenceType> a = new List<MyReferenceType> { new MyReferenceType(1, 2, 3, 0, 0, 0), new MyReferenceType(2, 1, 3, 0, 0, 0) };
			Assert.That(a.IndexOf(new MyReferenceType(1, 1, 1, 0, 0, 0)), Is.EqualTo(1));
		}

		#endregion

		#region IDictionary Inheritors.Add

		[Test, ExpectedException(typeof(ArgumentException))]
		public void ListDictionary_UsesEquals_P1()
		{
			ListDictionary d = new ListDictionary { { new MyReferenceType(1, 2, 3, 0, 0, 0), "1 2 3 0 0 0" } };

			d.Add(new MyReferenceType(1, 1, 1, 0, 0, 0), "1 1 1 0 0 0");
			Assert.Fail();
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void ListDictionary_Comparer_P4()
		{
			ListDictionary d = new ListDictionary(new MyReferenceType.Helper()) { { new MyReferenceType(0, 0, 0, 1, 2, 3), "0 0 0 1 2 3" } };

			d.Add(new MyReferenceType(0, 0, 0, 1, 1, 1), "0 0 0 1 1 1 1");
			Assert.Fail();
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void Hastable_UsesGetHashAndEquals_P3AndP1()
		{
			Hashtable d = new Hashtable { { new MyReferenceType(1, 2, 3, 0, 0, 0), "1 2 3 0 0 0" } };

			d.Add(new MyReferenceType(1, 0, 3, 0, 0, 0), "1 0 3 0 0 0");
			Assert.Fail();
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void Hashtable_UserGetHashAndEqualityComparer_P4AndP6()
		{
			Hashtable d = new Hashtable(new MyReferenceType.Helper()) { { new MyReferenceType(0, 0, 0, 1, 2, 3), "0 0 0 1 2 3" } };

			d.Add(new MyReferenceType(0, 0, 0, 1, 0, 3), "0 0 0 1 0 3");
			Assert.Fail();
		}

		#endregion

		#region IDictionary Inheritors.Contains

		[Test]
		public void ListDictionary_Contains_UsesEquals_P1()
		{
			ListDictionary d = new ListDictionary { { new MyReferenceType(1, 2, 3, 0, 0, 0), "1 2 3 0 0 0" } };
			Assert.That(d.Contains(new MyReferenceType(1, 1, 1, 0, 0, 0)), Is.True);
		}

		[Test]
		public void Hashtable_Contains_UsesGetHashAndEquals_P3AndP1()
		{
			Hashtable d = new Hashtable { { new MyReferenceType(1, 2, 3, 0, 0, 0), "1 2 3 0 0 0" } };
			Assert.That(d.Contains(new MyReferenceType(1, 1, 3, 0, 0, 0)), Is.True);
		}

		#endregion

		#region Dictionary<T,K>

		[Test, ExpectedException(typeof(ArgumentException))]
		public void Dictionary_UsesGetHashCodeAndEqualT_P2AndP3()
		{
			Dictionary<MyReferenceType, string> d = new Dictionary<MyReferenceType, string> { { new MyReferenceType(1, 2, 3, 0, 0, 0), "1 2 3 0 0 0" } };

			d.Add(new MyReferenceType(0, 2, 3, 0, 0, 0), "2 2 3 0 0");
			Assert.Fail();
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void Dictionary_UsesGetHashCodeAndEqualT_P5AndP6()
		{
			Dictionary<MyReferenceType, string> d = new Dictionary<MyReferenceType, string>(new MyReferenceType.Helper());
			d.Add(new MyReferenceType(0, 0, 0, 0, 1, 3), "0 0 0 0 1 3");

			d.Add(new MyReferenceType(0, 0, 0, 1, 1, 3), "0 0 0 1 1 3");
			Assert.Fail();
		}

		#endregion

		#region HashSet

		[Test]
		public void HashSet_Add_UsesGetHashAndEqualsT_P2AndP3()
		{
			HashSet<MyReferenceType> set = new HashSet<MyReferenceType> { new MyReferenceType(1, 2, 3, 0, 0, 0) };
			Assert.That(set.Add(new MyReferenceType(0, 2, 3, 0, 0, 0)), Is.False);
			Assert.That(set.Add(new MyReferenceType(0, 2, 1, 0, 0, 0)), Is.True);
			Assert.That(set.Add(new MyReferenceType(0, 1, 3, 0, 0, 0)), Is.True);
		}

		[Test]
		public void HashSet_Contains_UsesGetHashAndEqualsT_P2AndP3()
		{
			HashSet<MyReferenceType> set = new HashSet<MyReferenceType> { new MyReferenceType(1, 2, 3, 0, 0, 0) };
			Assert.That(set.Contains(new MyReferenceType(0, 2, 3, 0, 0, 0)), Is.True);
			Assert.That(set.Contains(new MyReferenceType(0, 2, 1, 0, 0, 0)), Is.False);
			Assert.That(set.Contains(new MyReferenceType(0, 1, 3, 0, 0, 0)), Is.False);
		}

		[Test]
		public void HashSet_Remove_UsesGetHashAndEqualsT_P2AndP3()
		{
			HashSet<MyReferenceType> set = new HashSet<MyReferenceType> { new MyReferenceType(1, 2, 3, 0, 0, 0) };

			set.Remove(new MyReferenceType(0, 2, 3, 0, 0, 0));
			Assert.That(set, Is.Empty);
		}

		[Test]
		public void HashSet_Add_UsesGetHashAndEqualsT_P5AndP6()
		{
			HashSet<MyReferenceType> set = new HashSet<MyReferenceType>(new MyReferenceType.Helper());
			set.Add(new MyReferenceType(0, 0, 0, 1, 2, 3));
			Assert.That(set.Add(new MyReferenceType(0, 0, 0, 0, 2, 3)), Is.False);
			Assert.That(set.Add(new MyReferenceType(0, 0, 0, 0, 2, 1)), Is.True);
			Assert.That(set.Add(new MyReferenceType(0, 0, 0, 0, 1, 3)), Is.True);
		}

		[Test]
		public void HashSet_Contains_UsesGetHashAndEqualsT_P5AndP6()
		{
			HashSet<MyReferenceType> set = new HashSet<MyReferenceType>(new MyReferenceType.Helper());
			set.Add(new MyReferenceType(0, 0, 0, 1, 2, 3));
			Assert.That(set.Contains(new MyReferenceType(0, 0, 0, 0, 2, 3)), Is.True);
			Assert.That(set.Contains(new MyReferenceType(0, 0, 0, 0, 2, 1)), Is.False);
			Assert.That(set.Contains(new MyReferenceType(0, 0, 0, 0, 1, 3)), Is.False);
		}

		#endregion
	}
}
