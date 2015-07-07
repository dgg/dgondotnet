using Owin;

namespace FeatureToggling.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseNancy();
		}
	}
}