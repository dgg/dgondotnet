using Nancy;

namespace FeatureToggling.Web.Modules
{
	public class TopLevel : NancyModule
	{
		public TopLevel()
		{
			new Features.TopLevel()
				.TryRegister(this, _ => 
					View["TopLevel"]);
		}
	}
}