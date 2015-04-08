using System;
using System.ComponentModel;
using System.Globalization;
using NMoneys;
using NMoneys.Extensions;

namespace DgonDotNet.Blog.Samples.NMoneysForDevs
{
	public class CleverDevStuff
	{
		public void GetCurrencyInstance_FromStaticShortCut()
		{
			Currency danishKrona = Currency.Dkk;
			Currency euro = Currency.Eur;
		}

		public void GetCurrencyInstance_FromCreationMethod()
		{
			Currency canadianDollar = Currency.Get(CurrencyIsoCode.CAD),
				euro = Currency.Get("EUR"),
				swedishKrona = Currency.Get(CultureInfo.GetCultureInfo("sv-SE"));

			try
			{
				var rogueCurrency = Currency.Get("IAmNotAnISOCode");
			}
			catch (InvalidEnumArgumentException) { }
		}

		public void GetCurrencyInstance_IDoNotLikeExceptions()
		{
			Currency aCurrency;
			bool couldBeObtained = Currency.TryGet(CurrencyIsoCode.CAD, out aCurrency);
			couldBeObtained = Currency.TryGet("EUR", out aCurrency);
			couldBeObtained = Currency.TryGet(CultureInfo.GetCultureInfo("sv-SE"), out aCurrency);

			bool couldNotBeObtained = Currency.TryGet("StillNotAnISOCode", out aCurrency);
		}

		public void CreateMoneyInstance_CtorMadness()
		{
			var zeroUndefinedCurrency = new Money();
			var threeNoCurrencies = new Money(3m);
			var twoAndAHalfAustralianDollars = new Money(2.5m, Currency.Aud);
			twoAndAHalfAustralianDollars = new Money(2.5m, CurrencyIsoCode.AUD);
			twoAndAHalfAustralianDollars = new Money(2.5m, "aud");
			twoAndAHalfAustralianDollars = new Money(twoAndAHalfAustralianDollars);
		}

		public void CreateMoneyInstance_SomeCreationMethods()
		{
			var twoAndAHalfAustralianDollars = Money.ForCulture(2.5m, CultureInfo.GetCultureInfo("en-AU"));
			var threeAndAnambientDependantCurrency = Money.ForCurrentCulture(3m);
		}

		public void CreateMoneyInstance_WithExtensionMethods()
		{
			var threeNoCurrencies = 3m.Xxx();
			var twoAndAHalfAustralianDollars = 2.5m.Aud();
			twoAndAHalfAustralianDollars = 2.5m.ToMoney(CurrencyIsoCode.AUD);
			twoAndAHalfAustralianDollars = 2.5m.ToMoney(Currency.Aud);
			twoAndAHalfAustralianDollars = CurrencyIsoCode.AUD.ToMoney(2.5m);
		}

		public void Comparing_Moneys()
		{
			var twoPounds = new Money(2, Currency.Pound);
			var threePounds = new Money(3, CurrencyIsoCode.GBP);
			var threeEuros = new Money(3, Currency.Euro);

			bool @true = twoPounds.CompareTo(threePounds) < 0;
			@true = threePounds >= twoPounds;

			object boxedThreePounds = (object) threePounds;
			@true = twoPounds.CompareTo(boxedThreePounds) < 0;

			try
			{
				twoPounds.CompareTo(threeEuros);
			}
			catch (DifferentCurrencyException) { }
		}

		public void Moneys_And_Equality()
		{
			var twoPounds = new Money(2, Currency.Pound);
			var anotherTwoPounds = new Money(2, Currency.Pound);
			var threePounds = new Money(3, CurrencyIsoCode.GBP);
			var threeEuros = new Money(3, Currency.Euro);

			bool areEqual = twoPounds.Equals(anotherTwoPounds);
			areEqual = twoPounds == anotherTwoPounds;

			object boxedTwoPounds = (object) anotherTwoPounds;
			areEqual = twoPounds.Equals(boxedTwoPounds);

			bool notEqual = twoPounds.Equals(threePounds);
			notEqual = threePounds.Equals(threeEuros);
			bool @true = twoPounds != threePounds;
		}

		public void Money_Arithmetic()
		{
			var twoPounds = new Money(2, Currency.Pound);
			var threePounds = new Money(3, CurrencyIsoCode.GBP);
			var threeEuros = new Money(3, Currency.Euro);

			Money fivePounds = twoPounds.Plus(threePounds);
			Money onePound = threePounds - twoPounds;

			Money youOweMeThreeEuros = -threeEuros;

			Money nowIHaveThoseThreeEuros = youOweMeThreeEuros.Abs();

			try
			{
				twoPounds.Minus(threeEuros);
			}
			catch (DifferentCurrencyException)
			{
			}
		}

		public void Do_something_With_The_Amount()
		{
			var twoAndAHalfAustralianDollars = 2.5m.Aud();
			Money twoDollars = twoAndAHalfAustralianDollars.Floor();
			Money threeDollars = twoAndAHalfAustralianDollars.RoundToNearestInt(MidpointRounding.AwayFromZero);
			Money twoFiftyFive = 2.553m.Aud().Round();
			twoDollars = 2.559m.Aud().Truncate();
			twoFiftyFive = 2.559m.Aud().TruncateToSignificantDecimalDigits();
		}

		public void Extensible_Arihtmetics()
		{
			Money performedOnSingleInstance = 2m.Eur().Perform(amount => amount*2);
			Money performedOnTwoInstances = 2m.Eur().Perform(1m.Eur(), (x, y) => -x - y);

			try
			{
				2m.Eur().Perform(1m.Gbp(), (_, __) => _);
			}
			catch(DifferentCurrencyException) { }
		}

		public void Money_ToString()
		{
			// default formatting, as specified by the currency "10,00 €"
			10m.Dkk().ToString();

			// custom format applied to currency "3.00"
			3m.Usd().ToString("N");

			// format provider used "3,00 €", better suited for countries with same currency and different number formatting
			3m.Eur().ToString(CultureInfo.GetCultureInfo("es-ES")); 
			
		}

		public void Money_Format()
		{
			// formatting with placeholders for currency symbol and amount "$ 03.00"
			3m.Usd().Format("{1} {0:00.00}");

			// rich, custom formatting "€ 1.500,00"
			1500m.Eur().Format("{1} {0:#,#.00}");
		}
	}
}
