using System;
using System.Diagnostics;

namespace DgonDotNet.Blog.Samples.AspNetProfiles
{
	public class ServiceClass
	{
		private readonly AnotherDataSource _another;

		public ServiceClass(AnotherDataSource another)
		{
			_another = another;
		}

		public HybridClass Retrieve(string email)
		{
			DateTime today = DateTime.Today;
			UserProfile profile = new UserProfile(email);
			return new HybridClass(email, profile.GetAge(today), profile.Gender, _another.Retrieve(email));
		}

		public void Persist(HybridClass hybrid)
		{
			Debug.Assert(hybrid != null, "Null instances cannot be persisted");

			var profile = new UserProfile(hybrid.Email);
			profile.SetAge(hybrid.AgeFromProfile);
			profile.Gender = hybrid.GenderFromProfile;

			// transactionality does not matter in this blog post
			profile.Save();

			_another.Save(hybrid.Email, hybrid.NotFromProfile);
		}
	}
}
