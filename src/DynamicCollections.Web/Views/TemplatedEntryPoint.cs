using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Views
{
	public class TemplatedEntryPoint<TModel>
	{
		private readonly HtmlHelper<TModel> _helper;
		private readonly string _indexReplacement;

		public TemplatedEntryPoint(HtmlHelper<TModel> helper, string indexReplacement)
		{
			_helper = helper;
			_indexReplacement = indexReplacement;
		}

		public MvcHtmlString TextBox<TProperty>(Expression<Func<TModel, TProperty>> zeroIndexedExpression, string value, object htmlAttributes = null)
		{
			TagBuilder text = input(HtmlHelper.GetInputTypeString(InputType.Text), zeroIndexedExpression, value, htmlAttributes);
			return MvcHtmlString.Create(text.ToString(TagRenderMode.SelfClosing));
		}

		private TagBuilder input<TProperty>(string type, Expression<Func<TModel, TProperty>> zeroIndexedExpression, string value, object htmlAttributes = null)
		{
			var input = new TagBuilder("input");
			setNonTemplatedAttributes(input, type, value, htmlAttributes);

			setTemplatedAttributes(input, zeroIndexedExpression);
			
			return input;
		}

		private static void setNonTemplatedAttributes(TagBuilder input, string type, string value, object htmlAttributes)
		{
			input.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
			input.MergeAttribute("type", type);
			input.MergeAttribute("value", value);
		}

		private void setTemplatedAttributes<TProperty>(TagBuilder tag, Expression<Func<TModel, TProperty>> zeroIndexedExpression)
		{
			string expression = ExpressionHelper.GetExpressionText(zeroIndexedExpression);
			TemplateInfo templateInfo = _helper.ViewContext.ViewData.TemplateInfo;

			string defaultName = templateInfo.GetFullHtmlFieldName(expression);
			var conventions = new IndexedExpressionConventions(_indexReplacement);
			tag.MergeAttribute("name", conventions.ReplaceName(defaultName));

			string defaultId = templateInfo.GetFullHtmlFieldId(expression);
			tag.MergeAttribute("id", conventions.ReplaceId(defaultId));

			ModelState state;
			if (_helper.ViewData.ModelState.TryGetValue(defaultName, out state) && (state.Errors.Count > 0))
			{
				tag.AddCssClass(HtmlHelper.ValidationInputCssClassName);
			}
			ModelMetadata metadata = ModelMetadata.FromLambdaExpression(zeroIndexedExpression, _helper.ViewData);
			tag.MergeAttributes(_helper.GetUnobtrusiveValidationAttributes(expression, metadata));
		}
	}
}