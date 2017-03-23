using System.IO;
using CLAP;
using DgonDotNet.Blog.Samples.NotLastConsole;

namespace DgonDotNet.Blog.Samples.NotLastConsole_CLAP
{
	public class Doer
	{
		private readonly TextWriter _dependencyForAVerb;

		public Doer(TextWriter dependencyForAVerb)
		{
			_dependencyForAVerb = dependencyForAVerb;
		}

		[Verb(Description = "Do something.")]
		public void Something(
			[Required, Description("place where the something was done")]
			string location,
			[Description("number of times something was done"), DefaultValue(1)]
			int times,
			[Description("include if the something was awesome")]
			bool awesome)
		{
			var cmd = new ADoerOfSomething(_dependencyForAVerb);
			var options = new OptionsForSomething
			{
				Location = location,
				Times = times,
				Awesome = awesome
			};
			cmd.Do(options);
		}

		[Verb(Aliases = "something-else", Description = "Do something else.")]
		public void SomethingElse(
			[Required, Description("places where the something else was done")]
			string[] locations,
			[Description("include if the something else was awesome")]
			bool awesome)
		{
			var cmd = new ADoerOfSomethingElse(_dependencyForAVerb);
			var options = new OptionsForSomethingElse
			{
				Locations = locations,
				NotSoAwesome = !awesome
			};
			cmd.Do(options);
		}
	}
}