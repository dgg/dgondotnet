using System.Collections.Generic;

namespace Dgg.Anug.DbC.Domain.NoContract
{
	public interface IDiscountCalculator
	{
		IEnumerable<Discount> Calculate(IEnumerable<WithContract.LineItem> items);
	}
}
