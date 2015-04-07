using System;
using System.Collections.Generic;
using System.Web.Profile;
using NUnit.Framework;
using Rhino.Mocks;

namespace DgonDotNet.Blog.Samples.AspNetProfiles
{
	[TestFixture]
	public class ServiceClassTester
	{
		public AnotherDataSource _another;
		public ServiceClass initSubject()
		{
			_another = MockRepository.GeneratePartialMock<AnotherDataSource>();
			return new ServiceClass(_another);
		}

		[Test]
		public void Retrieve_ExistingEmail_InformationFromProfileAndAnotherDataSource()
		{
			string existingEmail = "me@here.com";
			decimal fromAnotherSource = 10m;
			DateTime birthDay = new DateTime(1977, 3, 11);
			byte femaleRepresentation = 1;

			ProfileTestProvider provider = (ProfileTestProvider)ProfileManager.Provider;
			var subject = initSubject();
			_another.Stub(a => a.Retrieve(existingEmail)).Return(fromAnotherSource);
			provider.StubValues(
				new KeyValuePair<string, object>(UserProfile.DAYOFBIRTH, birthDay),
				new KeyValuePair<string, object>(UserProfile.GENDER, femaleRepresentation));

			HybridClass retrieved = subject.Retrieve(existingEmail);

			Assert.That(retrieved.NotFromProfile, Is.EqualTo(fromAnotherSource));
			// another post subject would be how to handle temporal-dependant clases, but not this one
			Assert.That(retrieved.AgeFromProfile.Value.Advent, Is.EqualTo(birthDay));
			Assert.That(retrieved.GenderFromProfile.Value, Is.EqualTo(AGenderEnum.Female));
		}

		[Test]
		public void Persist_InformationToProfileAndAnotherDataSource()
		{
			string email = "me@here.com";
			DateTime birthDay = new DateTime(1977, 3, 11), today = new DateTime(2010, 4, 30);
			byte maleRepresentation = 0;
			AnAgeValueObject age = new AnAgeValueObject(birthDay, today);
			HybridClass toBePersisted = new HybridClass(email, age, AGenderEnum.Male, 15m);

			ProfileTestProvider provider = (ProfileTestProvider)ProfileManager.Provider;
			ServiceClass subject = initSubject();
			subject.Persist(toBePersisted);

			_another.AssertWasCalled(a => a.Save(email, 15m));
			provider.AssertPropertyValue(UserProfile.DAYOFBIRTH, Is.EqualTo(birthDay));
			provider.AssertPropertyValue(UserProfile.GENDER, Is.EqualTo(maleRepresentation));
		}
	}
}
