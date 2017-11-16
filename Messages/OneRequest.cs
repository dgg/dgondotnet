using SwaggerSamples.CustomSamples;
using SwaggerSamples.Messages.Models;

namespace SwaggerSamples.Messages
{
	[HasCustomSample]
	public class OneRequest
    {
		public int I { get; set; }
		public string S { get; set; }
		[SampleValue(null)]
		public string B { get; set; }
		[SampleValue(2.4f)]
		public decimal N { get; set; }
		public InputDto D { get; set; }
	}
}
