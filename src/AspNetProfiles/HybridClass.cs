namespace DgonDotNet.Blog.Samples.AspNetProfiles
{
	public class HybridClass
	{
		public HybridClass(string email, AnAgeValueObject? ageFromProfile, AGenderEnum? genderFromProfile, decimal notFromProfile)
		{
			Email = email;
			AgeFromProfile = ageFromProfile;
			GenderFromProfile = genderFromProfile;
			NotFromProfile = notFromProfile;
		}

		public string Email { get; private set; }
		public AnAgeValueObject? AgeFromProfile { get; private set; }
		public AGenderEnum? GenderFromProfile { get; private set; }
		public decimal NotFromProfile { get; private set; }

		// do something interesting with all this data
	}
}
