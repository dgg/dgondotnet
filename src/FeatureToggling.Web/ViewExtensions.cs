using System;
using Nancy.ViewEngines.Razor;

namespace FeatureToggling.Web
{
	public static class ViewExtensions
	{
		private static string TopNavigation(this HtmlHelpers<object> helper)
		{
			return helper.RenderContext.Context.ViewBag.TopNavigation;
		}

		public static string ActiveFor(this HtmlHelpers<dynamic> helper, string navigation)
		{
			return navigation.Equals(helper.TopNavigation(), StringComparison.OrdinalIgnoreCase) ?
				"active" :
				string.Empty;
		}
	}
}