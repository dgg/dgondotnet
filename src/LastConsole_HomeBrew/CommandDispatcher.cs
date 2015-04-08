using System;
using System.Collections.Generic;
using DgonDotNet.Blog.Samples.LastConsole;

namespace DgonDotNet.Blog.Samples.LastConsole_HomeBrew
{
	public class CommandDispatcher
	{
		private static readonly IEqualityComparer<string> _comparer = StringComparer.OrdinalIgnoreCase;

		public void Dispatch(string[] args)
		{
			var parser = new OptionsParser();
			if (_comparer.Equals(args[0], "something"))
			{
				var doer = new ADoerOfSomething(Console.Out);
				doer.Do(parser.ParseSomething(args));
			}
			else if (_comparer.Equals(args[0], "something-else"))
			{
				var doer = new ADoerOfSomethingElse(Console.Out);
				doer.Do(parser.ParseSomethingElse(args));
			}
		}

		public bool CanDispatch(string[] args)
		{
			return args.Length >= 1 &&
				(_comparer.Equals(args[0], "something") ||
				_comparer.Equals(args[0], "something-else"));
		}
	}
}
