using System;
using System.ComponentModel;
using NUnit.Framework;
using Rhino.Mocks;

namespace DgonDotNet.Blog.Samples.AspNetProfiles
{
	[TestFixture]
	public class UserProfileTester
	{
		[Test]
		public void FirstName_DirectAccessToProfile()
		{
			string get = "get", set = "set";

			MockRepository mocks = new MockRepository();
			UserProfile subject = mocks.PartialMock<UserProfile>("name");
			using (mocks.Record())
			{
				subject.Expect(s => s.GetProperty<string>(UserProfile.FIRST_NAME)).Return(get);
				subject.Expect(s => s.SetProperty(UserProfile.FIRST_NAME, set));
			}

			using (mocks.Playback())
			{
				Assert.That(subject.FirstName, Is.EqualTo(get));
				subject.FirstName = set;
			}
		}

		[Test]
		public void Gender_NullProfileValue_Null()
		{
			MockRepository mocks = new MockRepository();
			UserProfile subject = mocks.PartialMock<UserProfile>("name");
			using (mocks.Record())
			{
				subject.Expect(s => s.GetProperty<byte?>(UserProfile.GENDER)).Return(null);
			}

			using (mocks.Playback())
			{
				Assert.That(subject.Gender, Is.Null);
			}
		}

		[Test]
		public void Gender_Null_ProfileNull()
		{
			MockRepository mocks = new MockRepository();
			UserProfile subject = mocks.PartialMock<UserProfile>("name");
			using (mocks.Record())
			{
				subject.Expect(s => s.SetProperty<byte?>(UserProfile.GENDER, null));
			}

			using (mocks.Playback())
			{
				subject.Gender = null;
			}
		}

		[Test]
		public void Gender_Defined_CorrectGender()
		{
			MockRepository mocks = new MockRepository();
			UserProfile subject = mocks.PartialMock<UserProfile>("name");

			using (mocks.Record())
			{
				subject.Stub(s => s.GetProperty<byte?>(UserProfile.GENDER)).Return(1);
				subject.Stub(s => s.SetProperty<byte?>(UserProfile.GENDER, 0));
			}

			using (mocks.Playback())
			{
				Assert.That(subject.Gender, Is.EqualTo(AGenderEnum.Female));
				subject.Gender = AGenderEnum.Male;
			}
		}

		[Test, ExpectedException(typeof(InvalidEnumArgumentException))]
		public void Gender_NotDefined_Exception()
		{
			byte nonDefinedGender = 255;
			MockRepository mocks = new MockRepository();
			UserProfile subject = mocks.PartialMock<UserProfile>("name");

			using (mocks.Record())
			{
				subject.Expect(s => s.GetProperty<byte?>(UserProfile.GENDER)).Return(nonDefinedGender);
			}

			using (mocks.Playback())
			{
				AGenderEnum? gender = subject.Gender;
			}
		}

		[Test]
		public void GetAge_NullProfileValue_Null()
		{
			MockRepository mocks = new MockRepository();
			UserProfile subject = mocks.PartialMock<UserProfile>("name");
			using (mocks.Record())
			{
				subject.Expect(s => s.GetProperty<DateTime?>(UserProfile.DAYOFBIRTH)).Return(null);
			}

			using (mocks.Playback())
			{
				Assert.That(subject.GetAge(new DateTime(2010, 3, 6)), Is.Null);
			}
		}

		[Test]
		public void SetAge_Null_NullProfile()
		{
			MockRepository mocks = new MockRepository();
			UserProfile subject = mocks.PartialMock<UserProfile>("name");
			using (mocks.Record())
			{
				subject.Expect(s => s.SetProperty<DateTime?>(UserProfile.DAYOFBIRTH, null));
			}

			using (mocks.Playback())
			{
				subject.SetAge(null);
			}
		}

		[Test]
		public void GetAge_NotNull_AdventInProfile()
		{
			DateTime advent = new DateTime(1977, 3, 11);
			MockRepository mocks = new MockRepository();
			UserProfile subject = mocks.PartialMock<UserProfile>("name");
			using (mocks.Record())
			{
				subject.Expect(s => s.GetProperty<DateTime?>(UserProfile.DAYOFBIRTH)).Return(advent);
			}

			using (mocks.Playback())
			{
				AnAgeValueObject? age = subject.GetAge(new DateTime(2010, 3, 6));
				Assert.That(age.Value.Years, Is.EqualTo(32));
			}
		}

		[Test]
		public void SetAge_NotNull_AdventInProfile()
		{
			DateTime advent = new DateTime(1977, 3, 11);
			AnAgeValueObject thirtyTwo = new AnAgeValueObject(advent, new DateTime(2010, 3, 6));
			MockRepository mocks = new MockRepository();
			UserProfile subject = mocks.PartialMock<UserProfile>("name");
			using (mocks.Record())
			{
				subject.Expect(s => s.SetProperty<DateTime?>(UserProfile.DAYOFBIRTH, advent));
			}

			using (mocks.Playback())
			{
				subject.SetAge(thirtyTwo);
			}
		}
	}
}