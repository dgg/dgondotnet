using System;
using System.Linq;
using NMoneys;
using NMoneys.Extensions;
using Raven.Abstractions.Data;
using Raven.Abstractions.Extensions;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace CustomIsRisky
{
	class Program
	{
		static void Main(string[] args)
		{
			naiveProjection();
			defaultSerialization();
			Console.ReadLine();
		}

		private static void naiveProjection()
		{
			using (IDocumentStore store = initStore())
			{
				resetIndex(store, new Snapshots_ByOwner());
				resetTransformer(store, new Naive.SnapshotTransformer());
				deleteAllOrders(store);

				using (IDocumentSession session = store.OpenSession())
				{
					storeSomeOrders(session);
					session
						.Query<Order, Snapshots_ByOwner>()
						.TransformWith<Naive.SnapshotTransformer, Snapshot>()
						.Where(c => c.Owner == "owner")
						.ToArray()
						.ForEach(s => Console.WriteLine(s.Total));
				}
			}
		}

		private static void deleteAllOrders(IDocumentStore store)
		{
			store.DatabaseCommands.DeleteByIndex("Raven/DocumentsByEntityName", new IndexQuery { Query = "Tag: Orders" });
		}

		private static void resetIndex(IDocumentStore store, AbstractIndexCreationTask index)
		{
			store.DatabaseCommands.DeleteIndex(index.IndexName);
			store.ExecuteIndex(index);
		}

		private static void resetTransformer(IDocumentStore store, AbstractTransformerCreationTask transformer)
		{
			store.DatabaseCommands.DeleteTransformer(transformer.TransformerName);
			store.ExecuteTransformer(transformer);
		}

		private static void storeSomeOrders(IDocumentSession session)
		{
			session.Store(new Order
			{
				Number = 1,
				Owner = "owner",
				Created = new DateTimeOffset(2013, 10, 24, 0, 0, 0, TimeSpan.Zero),
				HeaderProperty = "one",
				Currency = CurrencyIsoCode.DKK,
				Lines = new[]
				{
					new Line { ProductId = "x", Quantity = 2, Price = 12m.Dkk() },
					new Line { ProductId = "y", Quantity = 1, Price = 13m.Dkk() }
				}
			});
			session.Store(new Order
			{
				Number = 2,
				Owner = "another owner",
				Created = new DateTimeOffset(2013, 10, 23, 0, 0, 0, TimeSpan.Zero),
				HeaderProperty = "two",
				Currency = CurrencyIsoCode.DKK,
				Lines = new Line[0]
			});
			session.Store(new Order
			{
				Number = 3,
				Owner = "owner",
				Created = new DateTimeOffset(2013, 10, 23, 0, 0, 0, TimeSpan.Zero),
				HeaderProperty = "two",
				Currency = CurrencyIsoCode.DKK,
				Lines = new[]
				{
					new Line { ProductId = "z", Quantity = 12, Price = 24m.Dkk() }
				}
			});

			session.SaveChanges();
		}

		private static void defaultSerialization()
		{
			using (IDocumentStore store = initStore())
			{
				resetIndex(store, new Snapshots_ByOwner());
				resetTransformer(store, new Default.SnapshotTransformer());
				deleteAllOrders(store);

				using (IDocumentSession session = store.OpenSession())
				{
					storeSomeOrders(session);

					session
						.Query<Order, Snapshots_ByOwner>()
						.TransformWith<Default.SnapshotTransformer, Snapshot>()
						.Where(c => c.Owner == "owner")
						.ToArray()
						.ForEach(s => Console.WriteLine(s.Total));
				}
			}
		}

		private static void customSerialization()
		{
			using (IDocumentStore store = initStore())
			{
				var byOwner = new Snapshots_ByOwner();
				store.DatabaseCommands.DeleteIndex(byOwner.IndexName);
				store.ExecuteIndex(byOwner);

				var asSnapshot = new Default.SnapshotTransformer();
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
						Currency = CurrencyIsoCode.DKK,
						Lines = new[]
						{
							new Line { ProductId = "x", Quantity = 2, Price = 12m.Dkk() },
							new Line { ProductId = "y", Quantity = 1, Price = 13m.Dkk() }
						}
					});
					session.Store(new Order
					{
						Number = 2,
						Owner = "another owner",
						Created = new DateTimeOffset(2013, 10, 23, 0, 0, 0, TimeSpan.Zero),
						HeaderProperty = "two",
						Currency = CurrencyIsoCode.DKK,
						Lines = new Line[0]
					});
					session.Store(new Order
					{
						Number = 3,
						Owner = "owner",
						Created = new DateTimeOffset(2013, 10, 23, 0, 0, 0, TimeSpan.Zero),
						HeaderProperty = "two",
						Currency = CurrencyIsoCode.DKK,
						Lines = new[]
						{
							new Line { ProductId = "z", Quantity = 12, Price = 24m.Dkk() }
						}
					});

					session.SaveChanges();

					session
						.Query<Order, Snapshots_ByOwner>()
						.TransformWith<Default.SnapshotTransformer, Snapshot>()
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
