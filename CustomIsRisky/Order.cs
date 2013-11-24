﻿using System;

namespace CustomIsRisky
{
	public class Order
	{
		public int Id { get; set; }
		public DateTimeOffset Created { get; set; }
		public string HeaderProperty { get; set; }
		public Line[] Lines { get; set; }
	}
}