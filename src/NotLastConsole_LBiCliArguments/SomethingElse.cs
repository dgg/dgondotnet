using System;
using System.ComponentModel.DataAnnotations;
using DgonDotNet.Blog.Samples.NotLastConsole;
using LBi.Cli.Arguments;

namespace DgonDotNet.Blog.Samples.NotLastConsole_LBiCliArguments
{
	[ParameterSet("SomethingElse", Command = "something-else", HelpMessage = "Do something else.")]
	public class SomethingElse : IRunnable
	{
		[Parameter(HelpMessage = "places where the something else was done"), Required]
		public string[] Locations { get; set; }

		[Parameter(HelpMessage = "include if the something else was awesome")]
		public Switch Awesome { get; set; }

		public virtual void Run()
		{
			var inner = new ADoerOfSomethingElse(Console.Out);
			var options = new OptionsForSomethingElse
			{
				Locations = Locations,
				NotSoAwesome = !Awesome
			};
			inner.Do(options);
		}
	}
}