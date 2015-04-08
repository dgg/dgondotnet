using System.Collections.Generic;
using System.IO;
using DgonDotNet.Blog.Samples.LastConsole;
using ManyConsole;

namespace DgonDotNet.Blog.Samples.LastConsole_ManyConsole
{
	internal class DoSomethingElse : ConsoleCommand
	{
		private readonly ADoerOfSomethingElse _command;
		private readonly OptionsForSomethingElse _options;
		private readonly List<string> _locations;

		public DoSomethingElse(TextWriter output)
		{
			IsCommand("something-else", "Does something else");

			_options = new OptionsForSomethingElse();
			_locations = new List<string>();

			HasRequiredOption("locations|l=",
				"places where the something else was done", 
				_locations.Add);
			HasOption("awesome|a", 
				"include if the something else was awesome", 
				_ => _options.NotSoAwesome = false);

			_command = new ADoerOfSomethingElse(output);
		}

		public override int Run(string[] remainingArguments)
		{
			_options.Locations = _locations.ToArray();
			_command.Do(_options);

			return 0;
		}
	}
}