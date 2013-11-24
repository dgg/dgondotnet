using NMoneys;

namespace CustomIsRisky
{
	public class Line
	{
		public string ProductId { get; set; }
		public uint Quantity { get; set; }
		public Money Price { get; set; }
	}
}