using System.Web.Mvc;

namespace DgonDotNet.Blog.Samples.DynamicCollections.App_Start
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}