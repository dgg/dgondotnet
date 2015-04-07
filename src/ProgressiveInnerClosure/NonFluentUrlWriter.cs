using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	public class NonFluentUrlWriter
	{
		private static readonly char _separator = '/';
		public string WriteContent(CultureInfo language, string pageName)
		{
			StringBuilder sb = new StringBuilder();
			return sb.Append(_separator)
				.Append(language.Name)
				.Append(_separator)
				.Append("content")
				.Append(_separator)
				.Append(pageName)
				.ToString().ToLower();
		}

		public string WriteEntity(CultureInfo language, Guid id)
		{
			return writeEntity(language.Name, id.ToString());
		}

		public string WriteEntityOperation(CultureInfo language, string operation)
		{
			return writeEntity(language.Name, operation);
		}

		private static string writeEntity(string language, string page)
		{
			StringBuilder sb = new StringBuilder();
			return sb.Append(_separator)
				.Append(language)
				.Append(_separator)
				.Append("entity")
				.Append(_separator)
				.Append(page)
				.ToString().ToLower();
		}

		public string WriteComplex(CultureInfo language, ComplexArgument complex)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(_separator)
				.Append(language.Name)
				.Append(_separator)
				.Append("complex");

			if (!string.IsNullOrEmpty(complex.S1))
			{
				sb.Append(_separator);
				sb.Append(complex.S1);
				if (complex.S2 != null && complex.S2.Any())
				{
					foreach (var s in complex.S2)
					{
						appendIfNotEmpty(sb, s);
					}
					appendIfNotEmpty(sb, complex.S3);
				}
			}

			return sb.ToString().ToLower();
		}

		private static void appendIfNotEmpty(StringBuilder sb, string s)
		{
			if (!string.IsNullOrEmpty(s))
			{
				sb.Append(_separator).Append(s);
			}
		}
	}
}