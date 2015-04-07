using System;

namespace DgonDotNet.Blog.Samples.AspNetProfiles
{
	public struct AnAgeValueObject
	{
		public DateTime Advent { get; private set; }
		public DateTime Terminus { get; private set; }
		public TimeSpan Value { get; private set; }
		// highly unlikely that someone lives longer than 255 years
		public byte Years { get; private set; }

		public AnAgeValueObject(DateTime dateOfBirth, DateTime today) : this()
		{
			Advent = dateOfBirth.Subtract(dateOfBirth.TimeOfDay);
			Terminus = today.Subtract(today.TimeOfDay);

			Value = Terminus.Subtract(Advent);
			if (Value < TimeSpan.Zero) throw new ArgumentOutOfRangeException("today", "Negative ages make no sense.");
			calculateYears();
		}

		private void calculateYears()
		{
			Years = Convert.ToByte(Terminus.Year - Advent.Year);
			var months = Terminus.Month - Advent.Month;
			var days = Terminus.Day - Advent.Day;

			if (days < 0) months--;
			while (months < 0)
			{
				months += 12;
				Years--;
			}
		}

		public override string ToString()
		{
			return Years.ToString();
		}
	}
}