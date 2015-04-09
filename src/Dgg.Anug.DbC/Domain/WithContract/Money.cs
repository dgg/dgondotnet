using System;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace Dgg.Anug.DbC.Domain.WithContract
{
	public struct Money : IEquatable<Money>, IComparable<Money>
	{
		public Money(decimal amount, Currency currency) : this()
		{
			Contract.Ensures(Amount == amount);
			Contract.Ensures(Currency == currency);
			Amount = amount;
			Currency = currency;
		}

		public decimal Amount { get; private set; }
		public Currency Currency { get; private set; }

		public int CompareTo(Money other)
		{
			Contract.Requires(SameCurrency(other), "moneys need to have the same currency to be compared");
			return Amount.CompareTo(other.Amount);
		}

		public override string ToString()
		{
			Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
			return Amount.ToString(CultureInfo.InvariantCulture) + " " + Currency; 
		}

		public bool IsZero { get { return Amount.Equals(decimal.Zero); } }

		public static Money operator +(Money one, Money two)
		{
			Contract.Requires(one.SameCurrency(two), "moneys need to have the same currency to be added");
			return new Money(one.Amount + two.Amount, one.Currency);
		}

		public static Money operator *(Money money, int times)
		{
			Contract.Requires(times > 0);
			return new Money(money.Amount * times, money.Currency);
		}

		public static Money operator *(int times, Money money)
		{
			Contract.Requires(times > 0);
			return new Money(money.Amount * times, money.Currency);
		}

		public bool Equals(Money other)
		{
			return other.Amount == Amount && Equals(other.Currency, Currency);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (obj.GetType() != typeof (Money)) return false;
			return Equals((Money) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Amount.GetHashCode()*397) ^ Currency.GetHashCode();
			}
		}

		public static bool operator ==(Money left, Money right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Money left, Money right)
		{
			return !left.Equals(right);
		}

		public static bool operator <(Money money, Money other)
		{
			Contract.Requires(money.SameCurrency(other), "moneys need to have the same currency to be compared");
			return money.Amount < other.Amount;
		}

		public static bool operator >(Money money, Money other)
		{
			Contract.Requires(money.SameCurrency(other), "moneys need to have the same currency to be compared");
			return money.Amount > other.Amount;
		}

		public static bool operator <=(Money money, Money other)
		{
			Contract.Requires(money.SameCurrency(other), "moneys need to have the same currency to be compared");
			return money.Amount <= other.Amount;
		}

		public static bool operator >=(Money money, Money other)
		{
			Contract.Requires(money.SameCurrency(other), "moneys need to have the same currency to be compared");
			return money.Amount >= other.Amount;
		}

		[Pure]
		public bool SameCurrency(Money money)
		{
			return Currency == money.Currency;
		}
	}
}