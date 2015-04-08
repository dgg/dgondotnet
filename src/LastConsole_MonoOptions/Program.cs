using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DgonDotNet.Blog.Samples.LastConsole;
using Mono.Options;

namespace DgonDotNet.Blog.Samples.LastConsole_MonoOptions
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			bool help = false;

			var something = new OptionsForSomething();
			var somethingElse = new OptionsForSomethingElse();
			
			Action command = () => { };
			
			var locations = new List<string>();

			var set = new OptionSet();

			set
				.Add("something", "Does something", opt => command = 
					() => new ADoerOfSomething(Console.Out)
						.Do(something))
				.Add("something-else", "Does something else", opt => command = 
					() => new ADoerOfSomethingElse(Console.Out)
						.Do(somethingElse))
				.Add("awesome|a", "include if the something (else) was awesome", opt =>
				{
					something.Awesome = true;
					somethingElse.NotSoAwesome = false;
				})
				.Add<int>("times|t=", "number of times something was done", opt =>
				{
					something.Times = opt;
				})
				.Add("location|l:", "place or places where the something (else) was done", opt =>
				{
					something.Location = opt;
					locations.Add(opt);
					somethingElse.Locations = locations.ToArray();
				})
				.Add("help|h", "shows usage", _ => help = true);
			try
			{
				set.Parse(args);
				if (help)
				{
					showHelp(set);
				}
				else
				{
					command();
				}
			}
			catch (OptionException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private static void showHelp(OptionSet set)
		{
			TextWriter tw = Console.Out;

			tw.Write("Usage {0} <options>", exe());
			tw.WriteLine();
			tw.WriteLine();
			tw.WriteLine("<options> available:");
			set.WriteOptionDescriptions(tw);
		}

		private static string exe()
		{
			return Assembly.GetExecutingAssembly().GetName().Name.ToLowerInvariant() + ".exe";
		}
	}
}
