using Nancy;

namespace FeatureToggling.Web.Modules
{
	public class Optional : NancyModule
	{
		public Optional()
		{
			new Features.Optional()
				.TryActivate(this, _ => 
					View["Optional"]);
		}
	}
}