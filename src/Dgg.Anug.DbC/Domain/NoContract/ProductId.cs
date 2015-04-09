using System;
using System.Text.RegularExpressions;

namespace Dgg.Anug.DbC.Domain.NoContract
{
	public class ProductId : IEquatable<ProductId>
	{
		public ProductId(string id)
		{
			Id = id;
		}

		public string Id { get; private set; }

		public override string ToString()
		{
			return Id;
		}

		public static bool IsMatchingId(string id)
		{
			return _productIdPattern.IsMatch(id);
		}

		private static readonly Regex _productIdPattern = new Regex(@"^P-\([\d]{5}\)$",
			RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.CultureInvariant);

		public bool Equals(ProductId other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return StringComparer.OrdinalIgnoreCase.Equals(other.Id, Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (ProductId)) return false;
			return Equals((ProductId) obj);
		}

		public override int GetHashCode()
		{
			return (Id != null ? Id.GetHashCode() : 0);
		}

		public static ProductId Any = new ProductId("P-(00000)");
	}
}
