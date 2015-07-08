using System;
using FeatureSwitcher;
using Nancy;

namespace FeatureToggling.Web.Features
{
	public class Optional : IFeature
	{
		public bool TryActivate(NancyModule module, Func<dynamic, dynamic> method)
		{
			bool registered = this.Is().Enabled;
			if (registered) module.Get["/optional"] = method;
			return registered;
		}
	}
}