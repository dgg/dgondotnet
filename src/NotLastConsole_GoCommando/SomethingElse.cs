using System;
using DgonDotNet.Blog.Samples.NotLastConsole;
using GoCommando;

namespace DgonDotNet.Blog.Samples.NotLastConsole_GoCommando
{
	[Command("something-else")]
	[Description("Do something else")]
	public class SomethingElse : ICommand
	{
		private readonly ADoerOfSomethingElse _command;

		public SomethingElse()
		{
			_command = new ADoerOfSomethingElse(Console.Out);
		}

		[Parameter("locations", "l")]
		[Description("places where the something else was done")]
		public string[] Locations { get; set; }

		[Parameter("awesome", "a", optional: true)]
		[Description("include if the something else was awesome")]
		public bool Awesome { get; set; }

		public void Run()
		{
			var options = new OptionsForSomethingElse
			{
				Locations = Locations,
				NotSoAwesome = !Awesome
			};

			_command.Do(options);
		}
	}
}