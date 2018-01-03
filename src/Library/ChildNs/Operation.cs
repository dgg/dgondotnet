namespace BreakingChangeAnatomy.Library.ChildNs
{
	public static class Operation
	{
		public static TheReturn TheMethod(this TheType o, TheArgument argument)
		{
			// fake doing something
			var result = new TheReturn
			{
				Something = $"{o.TheProperty}{argument.Postfix}"
			};
			return result;
		}
	}
}
