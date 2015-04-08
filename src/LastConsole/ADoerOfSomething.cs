using System.IO;

namespace DgonDotNet.Blog.Samples.LastConsole
{
	public class ADoerOfSomething
	{
		private readonly TextWriter _output;

		public ADoerOfSomething(TextWriter output)
		{
			_output = output;
		}

		public void Do(OptionsForSomething something)
		{
			if (something != null)
			{
				_output.Write("I did something");
				if (something.Awesome)
				{
					_output.Write(" awesome");
				}
				int times = something.Times;
				if (times > 1)
				{
					_output.Write(" {0} times", times);
				}
				_output.Write(" in {0}", something.Location);
				_output.WriteLine();
			}
		}
	}
}