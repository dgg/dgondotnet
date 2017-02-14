using System.Collections.Generic;
using CommandLine;

namespace DgonDotNet.Blog.Samples.NotLastConsole_CommandLineParser
{
	[Verb("something-else", HelpText = "Do something else")]
	public class SomethingElse
	{
		[Option('l', "locations", HelpText = "places where the something else was done", Required = true, Separator = ',')]
		public IEnumerable<string> Locations { get; set; }
		[Option('a', "awesome", HelpText = "include if the something else was awesome", Required = false, Default = true)]
		public bool Awesome { get; set; }
	}
}