namespace CustomIsRisky
{
	public class Order
	{
		public int Id { get; set; }
		public string HeaderProperty { get; set; }
		public Line[] Lines { get; set; }
	}
}