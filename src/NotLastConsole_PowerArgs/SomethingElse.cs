using PowerArgs;

namespace DgonDotNet.Blog.Samples.NotLastConsole_PowerArgs
{
	public class SomethingElse
	{
		[ArgShortcut("l"), ArgRequired, ArgDescription("places where the something else was done")]
		public string[] Locations { get; set; }
		[ArgShortcut("a"), ArgDescription("include if the something else was awesome")]
		public bool Awesome { get; set; }
	}
}