using PowerArgs;

namespace DgonDotNet.Blog.Samples.NotLastConsole_PowerArgs
{
	public class Something
	{
		[ArgRequired, ArgShortcut("l"), ArgDescription("place where the something was done")]
		public string Location { get; set; }
		[ArgShortcut("t"), ArgDescription("number of times something was done")]
		public int Times { get; set; }
		[ArgShortcut("a"), ArgDescription("include if the something was awesome")]
		public bool Awesome { get; set; }
	}
}