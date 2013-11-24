using System;
using NMoneys;

namespace CustomIsRisky
{
	public class Order
	{
		public int Id { get; set; }
		public int Number { get; set; }
		public string Owner { get; set; }
		public DateTimeOffset Created { get; set; }
		public string HeaderProperty { get; set; }
		public CurrencyIsoCode Currency { get; set; }
		public Line[] Lines { get; set; }
	}
}