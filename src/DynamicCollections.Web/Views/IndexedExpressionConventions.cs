using System.Text.RegularExpressions;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Views
{
	public class IndexedExpressionConventions
	{
		private readonly string _replacement;
		private static readonly Regex _idMatcher = new Regex("(?<array>[a-z]+_)(?<index>\\d+)(?<property>__[a-z]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		private static readonly Regex _nameMatcher = new Regex("(?<array>[a-z]+\\[)(?<index>\\d+)(?<property>\\]\\.[a-z]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

		public IndexedExpressionConventions(string indexReplacement)
		{
			_replacement = "${array}" + indexReplacement + "${property}"; ;
		}

		public string ReplaceName(string nameForAnIndexedExpression)
		{
			return _nameMatcher.Replace(nameForAnIndexedExpression, _replacement);
		}

		public string ReplaceId(string idForAnIndexedExpression)
		{
			return _idMatcher.Replace(idForAnIndexedExpression, _replacement);
		}
	}
}