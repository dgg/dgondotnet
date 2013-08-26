using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Views
{
	public class BootstrapEntryPoint<TModel>
	{
		private readonly HtmlHelper<TModel> _helper;

		public BootstrapEntryPoint(HtmlHelper<TModel> helper)
		{
			_helper = helper;
		}

		public MvcHtmlString NavEntry(string linkText, string actionName, string controllerName)
		{
			string currentController = getValue("controller");
			string currentAction = getValue("action");

			bool isCurrent = controllerName.Equals(currentController, StringComparison.OrdinalIgnoreCase) &&
				actionName.Equals(currentAction, StringComparison.OrdinalIgnoreCase);

			var li = new TagBuilder("li")
			{
				InnerHtml = _helper.ActionLink(linkText, actionName, controllerName).ToString()
			};
			if (isCurrent)
			{
				li.AddCssClass("active");
			}

			return new MvcHtmlString(li.ToString(TagRenderMode.Normal));
		}

		private string getValue(string key)
		{
			return _helper.ViewContext.Controller.ValueProvider.GetValue(key).RawValue.ToString();
		}
	}
}