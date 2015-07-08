using Nancy;

namespace FeatureToggling.Web.Modules
{
	public class TopLevel : NancyModule
	{
		public TopLevel()
		{
			new Features.TopLevel()
				.TryActivate(this, _ => 
					View["TopLevel"]);
		}
	}
}