using System.Web.Mvc;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Controllers
{
	public abstract class DiscardController<TModel> : Controller
	{
		public abstract ActionResult Index(string save, string discard, TModel posted);

		protected bool isSave(string save, string discard)
		{
			return !string.IsNullOrEmpty(save) && string.IsNullOrEmpty(discard);
		}
	}
}