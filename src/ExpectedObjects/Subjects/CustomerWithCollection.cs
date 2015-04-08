using System.Collections.Generic;

namespace DgonDotNet.Blog.Samples.ExpectedObjects.Subjects
{
	class CustomerWithCollection
	{
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public IEnumerable<Address> Addresses { get; set; }
	}
}