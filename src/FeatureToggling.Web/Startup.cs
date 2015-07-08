using FeatureSwitcher.Configuration;
using Owin;

namespace FeatureToggling.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			FeatureSwitcher.Configuration.Features.Are
				.ConfiguredBy.AppConfig().And
				.NamedBy.TypeName();
			app.UseNancy();
		}
	}
}