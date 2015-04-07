using System;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	public class Entity
	{
		public Guid Id { get; set; }
		public decimal IgnoredByTheMapper { get; set; }
		public DateTime CreationDate { get; set; }
		public string Name { get; set; }
	}
}
