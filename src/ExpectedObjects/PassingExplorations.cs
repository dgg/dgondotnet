using System;
using DgonDotNet.Blog.Samples.ExpectedObjects.Subjects;
using DgonDotNet.Blog.Samples.ExpectedObjects.Support;
using NUnit.Framework;

namespace DgonDotNet.Blog.Samples.ExpectedObjects
{
	[TestFixture]
	public class PassingExplorations
	{
		[Test]
		public void Anonymous_SameShapeAndSameValues_Match()
		{
			Assert.That(new { A = "a" }, Does.Match(new { A = "a" }));
		}

		[Test]
		public void Anonymous_SameShapeAndDifferentValues_NotMatch()
		{
			Assert.That(new { A = "b" }, Does.Not.Match(new { A = "a" }));
			Assert.That(new { A = "b" }, Does.Not.Match(new { A = "B" }));
		}

		[Test]
		public void Anonymous_ExpectedIsSubsetOfActual_Match()
		{
			Assert.That(new { A = "a", B = 1 }, Does.Match(new { A = "a" }));
		}

		[Test]
		public void Anonymous_ExpectedIsSupersetOfActual_NotMatch()
		{
			Assert.That(new { A = "a" }, Does.Not.Match(new { A = "a", B = 1 }));
		}

		[Test]
		public void Anonymous_PrettyDeepWithSameValues_Match()
		{
			var actual = new
			{
				A = "a",
				B = new
				{
					C = 1,
					D = new { E = TimeSpan.Zero }
				}
			};

			var expected = new
			{
				A = "a",
				B = new
				{
					C = 1,
					D = new { E = TimeSpan.Zero }
				}
			};
			Assert.That(actual, Does.Match(expected));
		}

		[Test]
		public void Anonymous_DifferentDeepValue_NotMatch()
		{
			var actual = new
			{
				A = "a",
				B = new
				{
					C = 1,
					D = new { E = TimeSpan.Zero }
				}
			};

			var expected = new
			{
				A = "a",
				B = new
				{
					C = 1,
					D = new { E = TimeSpan.MaxValue }
				}
			};
			Assert.That(actual, Does.Not.Match(expected));
		}

		[Test]
		public void Anoymous_WithCollectionMemberWithSameShape_Match()
		{
			var complex = new CustomerWithCollection
			{
				Name = "name",
				PhoneNumber = "number",
				Addresses = new[]
				{
					new Address { AddressLineOne = "1_1", AddressLineTwo = "1_2", City = "city_1", State = "state_1", Zipcode = "zip_1"},
					new Address { AddressLineOne = "2_1", AddressLineTwo = "2_2", City = "city_2", State = "state_2", Zipcode = "zip_2"}
				}
			};

			var expected = new
			{
				Name = "name",
				Addresses = new object[]
				{
					new { State = "state_1"},
					new { Zipcode = "zip_2"}
				}
			};

			Assert.That(complex, Does.Match(expected));
		}

		[Test]
		public void Anoymous_WithCollectionMemberWithDifferentShape_NotMatch()
		{
			var complex = new CustomerWithCollection
			{
				Name = "name",
				PhoneNumber = "number",
				Addresses = new[]
				{
					new Address { AddressLineOne = "1_1", AddressLineTwo = "1_2", City = "city_1", State = "state_1", Zipcode = "zip_1"},
					new Address { AddressLineOne = "2_1", AddressLineTwo = "2_2", City = "city_2", State = "state_2", Zipcode = "zip_2"}
				}
			};

			var expected = new
			{
				Name = "name",
				Addresses = new object[]
				{
					new { State = "state_1"},
					new { NotThere = 0}
				}
			};

			Assert.That(complex, Does.Not.Match(expected));
		}
	}
}
