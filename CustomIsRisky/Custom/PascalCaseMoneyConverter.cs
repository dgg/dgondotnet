using System;
using NMoneys;
using Raven.Imports.Newtonsoft.Json;
using Raven.Imports.Newtonsoft.Json.Linq;

namespace CustomIsRisky.Custom
{
	public class PascalCaseMoneyConverter : JsonConverter
	{
		static class PascalTokens
		{
			public static readonly string Amount = "Amount", Currency = "Currency";
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var money = (Money)value;
			writer.WriteStartObject();

			writer.WritePropertyName(PascalTokens.Amount);
			writer.WriteValue(money.Amount);
			writer.WritePropertyName(PascalTokens.Currency);
			writer.WriteValue(money.CurrencyCode.AlphabeticCode());

			writer.WriteEndObject();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JToken token = JToken.ReadFrom(reader);
			return new Money(
				token[PascalTokens.Amount].Value<decimal>(),
				token[PascalTokens.Currency].Value<string>());
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof (Money) == objectType;
		}
	}
}