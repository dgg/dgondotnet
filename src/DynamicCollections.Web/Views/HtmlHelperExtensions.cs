using System.Web.Mvc;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Views
{
	public static class HtmlHelperExtensions
	{
		public static BootstrapEntryPoint<TModel> Bootstrap<TModel>(this HtmlHelper<TModel> helper)
		{
			return new BootstrapEntryPoint<TModel>(helper);
		}
	}
}