using System;
using BreakingChangeAnatomy.Library;
using BreakingChangeAnatomy.Library.ChildNs;

namespace BreakingChangeAnatomy.Client
{
	class Program
	{
		static void Main(string[] args)
		{
			var o = new TheType { TheProperty = 42m };
			var result = o.TheMethod(new TheArgument { Postfix = "!" });
			Console.WriteLine(result.Something);
			Console.ReadLine();
		}
	}
}
