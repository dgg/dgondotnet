using System.Collections.Generic;
using DgonDotNet.Blog.Samples.ExpectedObjects.Subjects;
using DgonDotNet.Blog.Samples.ExpectedObjects.Support;
using NUnit.Framework;

namespace DgonDotNet.Blog.Samples.ExpectedObjects
{
	[TestFixture]
	public class NotPassingExamples
	{
		[Test]
		public void FlatObjects_NotMatching_InformsOfNotMatchingProperties()
		{
			var expected = new FlatCustomer
			{
				Name = "Jane Doe",
				PhoneNumber = "5128651000"
			};

			var actual = new FlatCustomer
			{
				Name = "John Doe",
				PhoneNumber = "5128654242"
			};

			Assert.That(actual, Does.Match(expected));
		}

		[Test]
		public void ComposedObjects_NotMatching_RecursivelyInformsOfNotMatchingProperties()
		{
			var expected = new Customer
			{
				Name = "Jane Doe",
				PhoneNumber = "5128651000",
				Address = new Address
				{
					AddressLineOne = "123 Street",
					AddressLineTwo = string.Empty,
					City = "Austin",
					State = "TX",
					Zipcode = "78717"
				}
			};

			var actual = new Customer
			{
				Name = "John Doe",
				PhoneNumber = "5128654242",
				Address = new Address
				{
					AddressLineOne = "456 Street",
					AddressLineTwo = "Apt. 3",
					City = "Waco",
					State = "TX",
					Zipcode = "76701"
				}
			};

			Assert.That(actual, Does.Match(expected));
		}

		[Test]
		public void IndexableCollections_NotMatching_InformsOfNotMatchingIndex()
		{
			var expected = new[]
			{
				new Customer {Name = "Customer A"},
				new Customer {Name = "Customer B"}
			};

			var actual = new[]
			{
				new Customer {Name = "Customer A"},
				new Customer {Name = "Customer C"}
			};

			Assert.That(actual, Does.Match(expected));
		}

		[Test]
		public void Dictionaries_NotMatching_InformsOfMissingValues()
		{
			var expected = new Dictionary<string, string> { { "key1", "value1" } };
			var actual = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

			Assert.That(actual, Does.Match(expected));
		}

		[Test]
		public void PartialObjects_NotMatching_InformsAboutMissingAndNotMatchingProperties()
		{
			var expected = new Customer
			{
				Name = "Jane Doe",
				Address = new Address
				{
					City = "Austin"
				}
			};

			var actual = new Customer
			{
				Name = "John Doe",
				PhoneNumber = "5128654242",
				Address = new Address
				{
					AddressLineOne = "456 Street",
					AddressLineTwo = "Apt. 3",
					City = "Waco",
					State = "TX",
					Zipcode = "76701"
				}
			};

			Assert.That(actual, Does.Match(expected));
		}

		[Test]
		public void PartialObjects_ExpectedIsASubsetOfActual_InformsAboutMissingProperties()
		{
			var expected = new Customer
			{
				Name = "John Doe",
				Address = new Address
				{
					City = "Waco"
				}
			};

			var actual = new Customer
			{
				Name = "John Doe",
				PhoneNumber = "5128654242",
				Address = new Address
				{
					AddressLineOne = "456 Street",
					AddressLineTwo = "Apt. 3",
					City = "Waco",
					State = "TX",
					Zipcode = "76701"
				}
			};

			Assert.That(actual, Does.Match(expected));
		}

		[Test]
		public void PartialAnonymousObjects_NotMatching_InformsOfNotMatchingProperties()
		{
			var expected = new
			{
				Name = "Jane Doe",
				Address = new
				{
					City = "Austin"
				}
			};

			var actual = new Customer
			{
				Name = "John Doe",
				PhoneNumber = "5128654242",
				Address = new Address
				{
					AddressLineOne = "456 Street",
					AddressLineTwo = "Apt. 3",
					City = "Waco",
					State = "TX",
					Zipcode = "76701"
				}
			};

			Assert.That(actual, Does.Match(expected));
		}

		[Test]
		public void PartialAnonymousObjects_ExpectedIsASubsetOfActual_Pass()
		{
			var expected = new
			{
				Name = "John Doe",
				Address = new
				{
					City = "Waco"
				}
			};

			var actual = new Customer
			{
				Name = "John Doe",
				PhoneNumber = "5128654242",
				Address = new Address
				{
					AddressLineOne = "456 Street",
					AddressLineTwo = "Apt. 3",
					City = "Waco",
					State = "TX",
					Zipcode = "76701"
				}
			};

			Assert.That(actual, Does.Match(expected));
		}
	}
}
