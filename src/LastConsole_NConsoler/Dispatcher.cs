using System;
using DgonDotNet.Blog.Samples.LastConsole;
using NConsoler;

namespace DgonDotNet.Blog.Samples.LastConsole_NConsoler
{
	internal class Dispatcher
	{
		[Action("Do something")]
		public static void Something(
			[Required(Description = "place where the something was done")]
			string location, 
			[Optional(false, "a", Description = "include if the something was awesome")]
			bool awesome,
			[Optional(-1, "t", Description = "number of times something was done")]
			int times)
		{
			var options = new OptionsForSomething
			{
				Location = location,
				Awesome = awesome,
				Times = times < 0 ? 1 : times
			};

			var command = new ADoerOfSomething(Console.Out);
			command.Do(options);
		}

		[Action("Do something else")]
		public static void Something_Else(
			[Required(Description = "places where the something else was done")]
			string[] locations, 
			[Optional(false, "a", Description = "include if the something else was awesome")]
			bool awesome)
		{
			var options = new OptionsForSomethingElse
			{
				Locations = locations,
				NotSoAwesome = !awesome
			};

			var command = new ADoerOfSomethingElse(Console.Out);
			command.Do(options);	
		}
	}
}
