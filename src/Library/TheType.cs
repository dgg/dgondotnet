using BreakingChangeAnatomy.Library.ChildNs;

namespace BreakingChangeAnatomy.Library
{
    public class TheType
    {
        public decimal TheProperty { get; set; }

        public TheReturn TheMethod(TheArgument argument)
        {
            // fake doing something
            var result = new TheReturn
            {
                Something = $"{TheProperty} {argument.Postfix}"
            };
            return result;
        }
    }
}
