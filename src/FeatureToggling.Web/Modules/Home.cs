using Nancy;

namespace FeatureToggling.Web.Modules
{
	public class Home : NancyModule
	{
		public Home()
		{
			Get["/"] = _ => View["Home", "hello"];
		}	 
	}
}