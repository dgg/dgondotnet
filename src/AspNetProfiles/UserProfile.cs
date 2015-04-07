using System;
using System.ComponentModel;
using System.Web.Profile;

namespace DgonDotNet.Blog.Samples.AspNetProfiles
{
	public class UserProfile
	{
		private readonly ProfileBase _profile;

		public UserProfile(string userName) : this(ProfileBase.Create(userName)) { }

		public UserProfile(ProfileBase profile)
		{
			_profile = profile;
		}

		internal static readonly string FIRST_NAME = "FirstName";
		public string FirstName
		{
			get { return GetProperty<string>(FIRST_NAME); }
			set { SetProperty(FIRST_NAME, value); }
		}

		internal static readonly string DAYOFBIRTH = "DayOfBirth";
		public AnAgeValueObject? GetAge(DateTime today)
		{
			DateTime? dateTime = GetProperty<DateTime?>(DAYOFBIRTH);
			return dateTime.HasValue ? (AnAgeValueObject?)new AnAgeValueObject(dateTime.Value, today) : null;
		}

		public void SetAge(AnAgeValueObject? value)
		{
			DateTime? dateTime = value.HasValue ? (DateTime?)value.Value.Advent : null;
			SetProperty(DAYOFBIRTH, dateTime);
		}

		internal static readonly string GENDER = "Gender";
		public AGenderEnum? Gender
		{
			get
			{
				return convert(GetProperty<byte?>(GENDER));
			}
			set
			{
				SetProperty(GENDER, convert(value));
			}
		}

		#region enum conversion methods

		private static AGenderEnum? convert(byte? profileGender)
		{
			return profileGender.HasValue ? safeCast(profileGender.Value): null;
		}

		private static byte? convert(AGenderEnum? gender)
		{
			return gender.HasValue ? safeCast(gender.Value) : null;
		}

		private static byte? safeCast(AGenderEnum gender)
		{
			if (!Enum.IsDefined(typeof(AGenderEnum), gender)) throw new InvalidEnumArgumentException("gender", (int)gender, typeof(AGenderEnum));
			return (byte?) gender;
		}

		private static AGenderEnum? safeCast(byte gender)
		{
			if (!Enum.IsDefined(typeof(AGenderEnum), gender)) throw new InvalidEnumArgumentException("gender", gender, typeof(AGenderEnum));
			return (AGenderEnum?)Enum.ToObject(typeof(AGenderEnum), gender);
		}

		#endregion
		
		internal static readonly string ID = "Id";
		public Guid Id
		{
			get { return GetProperty<Guid>(ID); }
		}

		// ... more properties...

		public virtual bool IsDirty { get { return _profile.IsDirty; } }

		public virtual void Save()
		{
			_profile.Save();
		}

		internal virtual T GetProperty<T>(string propertyName)
		{
			return (T)_profile.GetPropertyValue(propertyName);
		}

		internal virtual void SetProperty<T>(string propertyName, T value)
		{
			_profile.SetPropertyValue(propertyName, value);
		}
	}
}