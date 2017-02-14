using System;
using DgonDotNet.Blog.Samples.NotLastConsole;
using GoCommando;

namespace DgonDotNet.Blog.Samples.NotLastConsole_GoCommando
{
	[Command("something")]
	[Description("Do something")]
	public class Something : ICommand
	{
		private readonly ADoerOfSomething _command;

		public Something()
		{
			_command = new ADoerOfSomething(Console.Out);
		}

		[Parameter("location", "l")]
		[Description("place where the something was done")]
		public string Location { get; set; }

		[Parameter("times", "t", optional: true, defaultValue: "-1")]
		[Description("include if the something was awesome")]
		public int Times { get; set; }

		[Parameter("awesome", "a", optional: true)]
		[Description("number of times something was done")]
		public bool Awesome { get; set; }

		public void Run()
		{
			var options = new OptionsForSomething
			{
				Location = Location,
				Awesome = Awesome,
				Times = Times
			};

			_command.Do(options);
		}
	}
}