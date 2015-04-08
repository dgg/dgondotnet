using System.IO;
using DgonDotNet.Blog.Samples.LastConsole;
using ManyConsole;

namespace DgonDotNet.Blog.Samples.LastConsole_ManyConsole
{
	public class DoSomething : ConsoleCommand
	{
		private readonly OptionsForSomething _options;
		private readonly ADoerOfSomething _command;

		public DoSomething(TextWriter output)
		{
			IsCommand("something", "Does something");
			
			_options = new OptionsForSomething();

			HasRequiredOption("location|l=", "place where the something was done", l => _options.Location = l);
			HasOption("awesome|a", "include if the something was awesome", _ => _options.Awesome = true);
			HasOption<int>("times|t=", "number of times something was done", t => _options.Times = t);
			
			_command = new ADoerOfSomething(output);
		}

		public override int Run(string[] remainingArguments)
		{
			_command.Do(_options);
			return 0;
		}
	}
}