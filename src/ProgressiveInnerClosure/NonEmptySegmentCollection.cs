using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	public class NonEmptySegmentCollection : IEnumerable<string>
	{
		private readonly List<string> _segments;

		public NonEmptySegmentCollection()
		{
			_segments = new List<string>();
		}

		public NonEmptySegmentCollection(int capacity)
		{
			_segments = new List<string>(capacity);
		}

		public NonEmptySegmentCollection Append(string segment)
		{
			if (!string.IsNullOrEmpty(segment)) _segments.Add(segment.ToLower());
			return this;
		}

		public NonEmptySegmentCollection Clear()
		{
			_segments.Clear();
			return this;
		}

		public IEnumerator<string> GetEnumerator()
		{
			return _segments.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private static readonly string _defautSeparator = ", ";
		public override string ToString()
		{
			return toDelimitedString(_segments, _defautSeparator);
		}

		public string ToString(string separator)
		{
			return toDelimitedString(_segments, separator);
		}

		private static string toDelimitedString(IEnumerable<string> segments, string separator)
		{
			if (segments == null) return null;

			StringBuilder sb = new StringBuilder();
			foreach (var item in segments)
			{
				sb.Append(item);
				sb.Append(separator);
			}
			if (sb.Length >= separator.Length)
			{
				sb.Remove(sb.Length - separator.Length, separator.Length);
			}
			return sb.ToString();
		}
	}
}
