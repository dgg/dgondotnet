using System;
using NMoneys;

namespace CustomIsRisky
{
	public class Snapshot
	{
		public int Number { get; set; }
		public string Owner { get; set; }
		public DateTimeOffset Created { get; set; }
		public uint LineCount { get; set; }
		public Money Total { get; set; }
	}
}