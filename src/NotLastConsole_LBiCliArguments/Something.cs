using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DgonDotNet.Blog.Samples.NotLastConsole;
using LBi.Cli.Arguments;

namespace DgonDotNet.Blog.Samples.NotLastConsole_LBiCliArguments
{
	[ParameterSet("Something", HelpMessage = "Do something.", Command = "something")]
	public class Something : IRunnable
	{
		[Parameter(HelpMessage = "place where the something was done"), Required]
		public string Location { get; set; }

		[Parameter(HelpMessage = "number of times something was done")]
		[DefaultValue("1")]
		public int Times { get; set; }

		[Parameter(HelpMessage = "include if the something was awesome")]
		public Switch Awesome { get; set; }

		public virtual void Run()
		{
			var inner = new ADoerOfSomething(Console.Out);
			var options = new OptionsForSomething
			{
				Location = Location,
				Times = Times,
				Awesome = Awesome.IsPresent
			};
			inner.Do(options);
		}
	}
}