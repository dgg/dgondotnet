using CommandLine;

namespace DgonDotNet.Blog.Samples.NotLastConsole_CommandLineParser
{
	[Verb("something", HelpText = "Do something")]
	public class Something
	{
		[Option('l', "location", HelpText = "place where the something was done", Required = true)]
		public string Location { get; set; }

		[Option('t', "times", HelpText = "number of times something was done", Default = 1, Required = false)]
		public int Times { get; set; }
		[Option('a', "awesome", HelpText = "include if the something was awesome", Required = false)]
		public bool Awesome { get; set; }
	}
}