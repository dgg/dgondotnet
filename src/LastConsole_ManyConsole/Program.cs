using System;
using ManyConsole;

namespace DgonDotNet.Blog.Samples.LastConsole_ManyConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			//var commands = ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(Program));

			var commands = new ConsoleCommand[]
			{
				new DoSomething(Console.Out),
				new DoSomethingElse(Console.Out)
			};
			ConsoleCommandDispatcher.DispatchCommand(commands, args, Console.Out, true);
		}
	}
}
