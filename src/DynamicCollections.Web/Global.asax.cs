using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DgonDotNet.Blog.Samples.DynamicCollections.App_Start;

namespace DgonDotNet.Blog.Samples.DynamicCollections
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
	}
}