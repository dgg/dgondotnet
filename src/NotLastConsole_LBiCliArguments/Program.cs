using LBi.Cli.Arguments;

namespace DgonDotNet.Blog.Samples.NotLastConsole_LBiCliArguments
{
	class Program
	{
		static void Main(string[] args)
		{
			var parser = new ArgumentParser<IRunnable>(typeof(Something), typeof(SomethingElse));
			IRunnable runnable;
			if (parser.TryParse(args, out runnable))
			{
				runnable.Run();
			}
		}
	}
}
