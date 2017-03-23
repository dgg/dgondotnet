using System;
using CLAP;

namespace DgonDotNet.Blog.Samples.NotLastConsole_CLAP
{
	class Program
	{
		static void Main(string[] args)
		{
			var parser = new Parser<Doer>();
			parser.Register.EmptyHelpHandler(Console.WriteLine);
			parser.Register.HelpHandler("?,h,help", Console.WriteLine);
			parser.Register.ErrorHandler(ex =>
			{
				ex.ReThrow = false;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex.Exception.Message);
				Console.ResetColor();
			});
			parser.Run(args, new Doer(Console.Out));
		}
	}
}
