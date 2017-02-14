using System;
using System.IO;
using DgonDotNet.Blog.Samples.NotLastConsole;
using GoCommando;

namespace DgonDotNet.Blog.Samples.NotLastConsole_GoCommando
{
	[Command("something-else")]
	[Description("Do something else")]
	public class SomethingElse : ICommand
	{
		private readonly ADoerOfSomethingElse _command;

		public SomethingElse(TextWriter writer)
		{
			_command = new ADoerOfSomethingElse(writer);
		}

		[Parameter("locations", "l")]
		[Description("places where the something else was done")]
		[Example("singleLocation")]
		[Example("multiple,comma-separated-locations")]
		public string Locations { get; set; }

		[Parameter("awesome", "a", optional: true)]
		[Description("include if the something else was awesome")]
		public bool Awesome { get; set; }

		private static readonly char[] _comma = {','};

		public void Run()
		{
			var options = new OptionsForSomethingElse
			{
				Locations = Locations.Split(_comma, StringSplitOptions.RemoveEmptyEntries),
				NotSoAwesome = !Awesome
			};

			_command.Do(options);
		}
	}
}