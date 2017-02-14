using System;
using System.Linq;
using CommandLine;
using DgonDotNet.Blog.Samples.NotLastConsole;

namespace DgonDotNet.Blog.Samples.NotLastConsole_CommandLineParser
{
	class Program
	{
		static void Main(string[] args)
		{
			Parser.Default.ParseArguments<Something, SomethingElse>(args).MapResult(
				(Something something) =>
				{
					var options = new OptionsForSomething
					{
						Location = something.Location,
						Times = something.Times,
						Awesome = something.Awesome
					};
					var command = new ADoerOfSomething(Console.Out);
					command.Do(options);
					return 0;
				},
				(SomethingElse somethingElse) =>
				{
					var options = new OptionsForSomethingElse
					{
						Locations = somethingElse.Locations.ToArray(),
						NotSoAwesome = !somethingElse.Awesome
					};
					var command = new ADoerOfSomethingElse(Console.Out);
					command.Do(options);
					return 0;
				},
				errors => -1);
		}
	}
}
