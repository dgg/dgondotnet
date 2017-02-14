using System;
using GoCommando;

namespace DgonDotNet.Blog.Samples.NotLastConsole_GoCommando
{
	internal class CustomFactory : ICommandFactory
	{
		public ICommand Create(Type commandType)
		{
			// do some extremelly poor-man's service locations
			if (commandType == typeof(Something))
			{
				return new Something(Console.Out);
			}
			if (commandType == typeof(SomethingElse))
			{
				return new SomethingElse(Console.Out);
			}
			throw new ArgumentException($"Unknown command type: {commandType}");
		}

		public void Release(ICommand command)
		{
			// we could gently free up resources from commands here
		}
	}
}