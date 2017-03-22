using DgonDotNet.Blog.Samples.NotLastConsole;
using Microsoft.Extensions.CommandLineUtils;

namespace DgonDotNet.Blog.Samples.NotLastConsole_CommandLineUtils
{
	class Program
	{
		static void Main(string[] args)
		{

			var app = new CommandLineApplication();
			app.HelpOption("-h | -? | --help");
			
			app.Commands.Add(new Something(app.OptionHelp.Template));

			CommandArgument locations = null;
			CommandOption awesome = null;
			app.Command("something-else", somethingElse =>
			{
				somethingElse.Description = "Do something else";
				somethingElse.HelpOption(app.OptionHelp.Template);

				locations = somethingElse.Argument(
					"-l | --locations", 
					"places where the something else was done",
					multipleValues: true);
				awesome = somethingElse.Option("-a | --awesome", "include if the something else was awesome",
					CommandOptionType.NoValue);
			}).OnExecute(() =>
			{
				var cmd = new ADoerOfSomethingElse(app.Out);
				cmd.Do(new OptionsForSomethingElse
				{
					Locations = locations.Values.ToArray(),
					NotSoAwesome = !awesome.HasValue()
				});

				return 0;
			});
			app.Execute(args);
		}
	}
}
