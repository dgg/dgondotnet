using PowerArgs;

namespace DgonDotNet.Blog.Samples.NotLastConsole_PowerArgs
{
	class Program
	{
		static void Main(string[] args)
		{
			ArgAction<Doer> action = Args.InvokeAction<Doer>(args);
		}
	}
}
