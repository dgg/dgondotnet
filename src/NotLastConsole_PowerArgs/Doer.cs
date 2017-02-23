using DgonDotNet.Blog.Samples.NotLastConsole;
using PowerArgs;

namespace DgonDotNet.Blog.Samples.NotLastConsole_PowerArgs
{
	[ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
	[TabCompletion]
	public class Doer
	{
		[ArgRequired]
		[ArgPosition(0)]
		public string Action { get; set; }

		public Something SomethingArgs { get; set; }
		public SomethingElse SomethingElseArgs { get; set; }

		public static void Something(Something args)
		{
			var options = new OptionsForSomething
			{
				Location = args.Location,
				Times = args.Times,
				Awesome = args.Awesome
			};

			var command = new ADoerOfSomething(System.Console.Out);
			command.Do(options);
		}

		public static void SomethingElse(SomethingElse args)
		{
			var options = new OptionsForSomethingElse
			{
				Locations = args.Locations,
				NotSoAwesome = !args.Awesome
			};

			var command = new ADoerOfSomethingElse(System.Console.Out);
			command.Do(options);
		}
	}
}