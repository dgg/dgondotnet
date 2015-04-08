using System;
using System.Reflection;

namespace DgonDotNet.Blog.Samples.LastConsole_HomeBrew
{
	class Program
	{
		static void Main(string[] args)
		{
			var dispatcher = new CommandDispatcher();
			if (dispatcher.CanDispatch(args))
			{
				dispatcher.Dispatch(args);
			}
			else
			{
				showUsage();
			}
		}

		private static void showUsage()
		{
			Console.WriteLine("Incorrect parameter set. Usage:");
			Console.WriteLine("\t{0} something/something-else yadi yadi yada...",
				Assembly.GetExecutingAssembly().GetName().Name.ToLowerInvariant());
		}
	}
}
