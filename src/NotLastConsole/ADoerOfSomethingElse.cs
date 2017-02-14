using System.IO;

namespace DgonDotNet.Blog.Samples.NotLastConsole
{
	public class ADoerOfSomethingElse
	{
		private readonly TextWriter _output;

		public ADoerOfSomethingElse(TextWriter output)
		{
			_output = output;
		}

		public void Do(OptionsForSomethingElse somethingElse)
		{
			if (somethingElse != null)
			{
				_output.Write("I did something else");
				if (somethingElse.NotSoAwesome)
				{
					_output.Write(" not so awesome");
				}
				_output.WriteLine(" in {0}", string.Join(", ", somethingElse.Locations));

				_output.WriteLine();
			}
		}
	}
}