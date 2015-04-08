using System;
using DgonDotNet.Blog.Samples.LastConsole;

namespace DgonDotNet.Blog.Samples.LastConsole_HomeBrew
{
	public class OptionsParser
	{
		public OptionsForSomething ParseSomething(string[] args)
		{
			int indexOfLocation = Array.IndexOf(args, "-location");
			string location = args[indexOfLocation + 1];

			int indexOfTimes = Array.IndexOf(args, "-times");
			int times;
			if (!int.TryParse(args[indexOfTimes + 1], out times))
			{
				times = 1;
			}

			bool awesome = Array.IndexOf(args, "-awesome") >= 0;

			return new OptionsForSomething
			{
				Location = location,
				Times = times,
				Awesome = awesome
			};
		}

		public OptionsForSomethingElse ParseSomethingElse(string[] args)
		{
			int indexOfLocations = Array.IndexOf(args, "-locations");
			string[] locations = args[indexOfLocations + 1].Split(',');

			bool notSoAwesome = Array.IndexOf(args, "-awesome") < 0;

			return new OptionsForSomethingElse
			{
				Locations = locations,
				NotSoAwesome = notSoAwesome
			};
		}
	}
}