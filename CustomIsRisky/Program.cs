using System;
using System.Linq;
using NMoneys;
using NMoneys.Extensions;
using Raven.Abstractions.Data;
using Raven.Abstractions.Extensions;
using Raven.Client;
using Raven.Client.Document;

namespace CustomIsRisky
{
	class Program
	{
		static void Main(string[] args)
		{
			defaultSerialization();
			Console.ReadLine();
		}

		private static void defaultSerialization()
		{
			using (IDocumentStore store = initStore())
			{
				var byOwner = new Snapshots_ByOwner();
				store.DatabaseCommands.DeleteIndex(byOwner.IndexName);
				store.ExecuteIndex(byOwner);

				var asSnapshot = new SnapshotTransformer();
				store.DatabaseCommands.DeleteTransformer(asSnapshot.TransformerName);
				store.ExecuteTransformer(asSnapshot);

				store.DatabaseCommands.DeleteByIndex("Raven/DocumentsByEntityName", new IndexQuery { Query = "Tag: Orders" });

				using (IDocumentSession session = store.OpenSession())
				{
					session.Store(new Order
					{
						Number = 1,
						Owner = "owner",
						Created = new DateTimeOffset(2013, 10, 24, 0, 0, 0, TimeSpan.Zero),
						HeaderProperty = "one",
						Currency = CurrencyIsoCode.EUR,
						Lines = new[]
						{
							new Line { ProductId = "x", Quantity = 2, Price = 12m.Eur() },
							new Line { ProductId = "y", Quantity = 1, Price = 13m.Eur() }
						}
					});
					session.Store(new Order
					{
						Number = 2,
						Owner = "another owner",
						Created = new DateTimeOffset(2013, 10, 23, 0, 0, 0, TimeSpan.Zero),
						HeaderProperty = "two",
						Currency = CurrencyIsoCode.EUR,
						Lines = new Line[0]
					});
					session.Store(new Order
					{
						Number = 3,
						Owner = "owner",
						Created = new DateTimeOffset(2013, 10, 23, 0, 0, 0, TimeSpan.Zero),
						HeaderProperty = "two",
						Currency = CurrencyIsoCode.EUR,
						Lines = new[]
						{
							new Line { ProductId = "z", Quantity = 12, Price = 24m.Eur() }
						}
					});

					session.SaveChanges();

					session
						.Query<Order, Snapshots_ByOwner>()
						.TransformWith<SnapshotTransformer, Snapshot>()
						.Where(c => c.Owner == "owner")
						.ToArray()
						.ForEach(s => Console.WriteLine(s.Total));
				}
			}
		}

		private static IDocumentStore initStore()
		{
			var store = new DocumentStore
			{
				Url = "http://localhost:8081",
				DefaultDatabase = "CustomIsRisky"
			};

			store.Initialize();
			return store;
		}
	}
}
