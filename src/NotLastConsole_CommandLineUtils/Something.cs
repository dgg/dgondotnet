using System;
using System.Globalization;
using DgonDotNet.Blog.Samples.NotLastConsole;
using Microsoft.Extensions.CommandLineUtils;

namespace DgonDotNet.Blog.Samples.NotLastConsole_CommandLineUtils
{
	public class Something : CommandLineApplication
	{
		public Something(string optionHelpTemplate)
		{
			Name = "something";
			Description = "Do something";

			_location = Option("-l | --location", "place where the something was done", CommandOptionType.SingleValue);
			_times = Option("-t | --times", "number of times something was done", CommandOptionType.SingleValue);
			_awesome = Option("-a | --awesome", "include if the something was awesome", CommandOptionType.NoValue);

			HelpOption(optionHelpTemplate);
			OnExecute((Func<int>) run);
		}

		private int run()
		{
			if (!_location.HasValue())
			{
				Error.WriteLine($"The argument '{_location.LongName}' is required.");
				ShowHelp(Name);
				return 1;
			}

			var cmd = new ADoerOfSomething(Out);
			int times;
			if (!int.TryParse(_times.Value(), NumberStyles.Integer, CultureInfo.InvariantCulture, out times))
			{
				times = 1;
			}
			OptionsForSomething options = new OptionsForSomething
			{
				Location = _location.Value(),
				Awesome = _awesome.HasValue(),
				Times = times
			};
			cmd.Do(options);
			return 0;
		}

		private readonly CommandOption _location, _awesome, _times;
	}
}