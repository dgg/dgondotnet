using System;
using System.Globalization;

namespace Dgg.Anug.DbC.Domain.NoContract
{
	public struct Money : IEquatable<Money>, IComparable<Money>
	{
		public Money(decimal amount, WithContract.Currency currency) : this()
		{
			Amount = amount;
			Currency = currency;
		}

		public decimal Amount { get; private set; }
		public WithContract.Currency Currency { get; private set; }

		public int CompareTo(Money other)
		{
			return Amount.CompareTo(other.Amount);
		}

		public override string ToString()
		{
			return Amount.ToString(CultureInfo.InvariantCulture) + " " + Currency; 
		}

		public bool IsZero { get { return Amount.Equals(decimal.Zero); } }

		public static Money operator +(Money one, Money two)
		{
			return new Money(one.Amount + two.Amount, one.Currency);
		}

		public static Money operator *(Money money, int times)
		{
			return new Money(money.Amount * times, money.Currency);
		}

		public static Money operator *(int times, Money money)
		{
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
			return money.Amount < other.Amount;
		}

		public static bool operator >(Money money, Money other)
		{
			return money.Amount > other.Amount;
		}

		public static bool operator <=(Money money, Money other)
		{
			return money.Amount <= other.Amount;
		}

		public static bool operator >=(Money money, Money other)
		{
			return money.Amount >= other.Amount;
		}

		public bool SameCurrency(Money money)
		{
			return Currency == money.Currency;
		}
	}
}