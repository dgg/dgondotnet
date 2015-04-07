namespace DgonDotNet.Blog.Samples.AspNetProfiles
{
	public class AnotherDataSource
	{
		public virtual decimal Retrieve(string email)
		{
			// boring infrastructure code to retrieve 5
			return 5m;
		}

		public virtual void Save(string email, decimal property)
		{
			// boring infrastructure code to save the value somewhere
		}
	}
}