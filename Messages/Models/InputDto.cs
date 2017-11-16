using SwaggerSamples.CustomSamples;

namespace SwaggerSamples.Messages.Models
{
	public class InputDto
    {
		[SampleValue(42)]
		public int I { get; set; }
		[SampleValue("meaningful")]
		public string S { get; set; }
		[SampleValues("a", "b")]
		public string[] A { get; set; }
	}
}
