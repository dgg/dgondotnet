using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Dgg.Anug.DbC.Domain.WithContract
{
	[ContractClass(typeof(DiscountCalculatorContract))]
	public interface IDiscountCalculator
	{
		IEnumerable<Discount> Calculate(IEnumerable<LineItem> items);
	}

	[ContractClassFor(typeof(IDiscountCalculator))]
	public abstract class DiscountCalculatorContract : IDiscountCalculator
	{
		public IEnumerable<Discount> Calculate(IEnumerable<LineItem> items)
		{
			Contract.Ensures(Contract.Result<IEnumerable<Discount>>() != null);
			return null;
		}
	}
}
