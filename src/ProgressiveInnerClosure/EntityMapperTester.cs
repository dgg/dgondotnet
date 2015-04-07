using System;
using System.Globalization;
using DgonDotNet.Blog.Samples.ProgressiveInnerClosure.ClosureMembers;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	[TestFixture]
	public class EntityMapperTester
	{
		[Test]
		public void Map_CannotStubMethodChain_Fail()
		{
			CultureInfo spanish = new CultureInfo("es-ES");
			string strId = "3A9779A4-9DCB-4FAC-ABBD-E61D8B27A8E4", name = "myself";
			Guid id = new Guid(strId);
			DateTime created = new DateTime(1977, 3, 11);
			string expectedUrl = "url";
			
			Entity from = new Entity { Id = id, CreationDate = created, Name = name };
			IUrlWriter writer = MockRepository.GenerateStub<IUrlWriter>();
			var subject = new EntityMapper(writer);
			writer.Stub(w => w.Write(url => url.In(spanish).Entity(id))).Return(expectedUrl);

			EntityDto to = subject.Map(from, spanish);
			Assert.That(to.Id, Is.EqualTo(strId));
			Assert.That(to.Name, Is.EqualTo(name));
			Assert.That(to.CreationDate, Is.EqualTo("19770311"));
			Assert.That(to.Url, Is.EqualTo(expectedUrl));
		}

		[Test]
		public void Map_Rhino_CheapWorkaround_Pass()
		{
			CultureInfo spanish = new CultureInfo("es-ES");
			string strId = "3A9779A4-9DCB-4FAC-ABBD-E61D8B27A8E4", name = "myself";
			Guid id = new Guid(strId);
			DateTime created = new DateTime(1977, 3, 11);
			string expectedUrl = "url";

			Entity from = new Entity { Id = id, CreationDate = created, Name = name };
			IUrlWriter writer = MockRepository.GenerateStub<IUrlWriter>();
			var subject = new EntityMapper(writer);
			writer.Stub(w => w.Write(Arg<Func<IStart,IEnd>>.Is.Anything)).Return(expectedUrl);

			EntityDto to = subject.Map(from, spanish);
			Assert.That(to.Id, Is.EqualTo(strId));
			Assert.That(to.Name, Is.EqualTo(name));
			Assert.That(to.CreationDate, Is.EqualTo("19770311"));
			Assert.That(to.Url, Is.EqualTo(expectedUrl));
		}

		[Test]
		public void Map_HandCodedDouble_Pass()
		{
			CultureInfo spanish = new CultureInfo("es-ES");
			string strId = "3A9779A4-9DCB-4FAC-ABBD-E61D8B27A8E4", name = "myself";
			Guid id = new Guid(strId);
			DateTime created = new DateTime(1977, 3, 11);
			string expectedUrl = "url";

			Entity from = new Entity { Id = id, CreationDate = created, Name = name };
			var writer = new UrlWriterDouble();
			var subject = new EntityMapper(writer);
			writer.StubAll(url => url.In(spanish).Entity(id), expectedUrl);

			EntityDto to = subject.Map(from, spanish);
			Assert.That(to.Id, Is.EqualTo(strId));
			Assert.That(to.Name, Is.EqualTo(name));
			Assert.That(to.CreationDate, Is.EqualTo("19770311"));
			Assert.That(to.Url, Is.EqualTo(expectedUrl));
		}

		[Test]
		public void Map_HandCodedDouble_Fail()
		{
			CultureInfo spanish = new CultureInfo("es-ES");
			string strId = "3A9779A4-9DCB-4FAC-ABBD-E61D8B27A8E4", name = "myself";
			Guid id = new Guid(strId);
			DateTime created = new DateTime(1977, 3, 11);
			string expectedUrl = "url";

			Entity from = new Entity { Id = id, CreationDate = created, Name = name };
			var writer = new UrlWriterDouble();
			var subject = new EntityMapper(writer);
			writer.StubAll(url => url.In(CultureInfo.InvariantCulture).Entity(id), expectedUrl);

			subject.Map(from, spanish);
		}

		[Test]
		public void Map_ExtendedDouble_Pass()
		{
			CultureInfo spanish = new CultureInfo("es-ES");
			string strId = "3A9779A4-9DCB-4FAC-ABBD-E61D8B27A8E4", name = "myself";
			Guid id = new Guid(strId);
			DateTime created = new DateTime(1977, 3, 11);
			string expectedUrl = "url";

			Entity from = new Entity { Id = id, CreationDate = created, Name = name };
			var writer = new UrlWriterDouble();
			var subject = new EntityMapper(writer);

			EntityDto to = null;
			writer
				.Arrange(url => url.In(spanish))
				.Arrange(url => url.Entity(id), expectedUrl)
				.Act(()=> to = subject.Map(from, spanish));

			Assert.That(to.Id, Is.EqualTo(strId));
			Assert.That(to.Name, Is.EqualTo(name));
			Assert.That(to.CreationDate, Is.EqualTo("19770311"));
			Assert.That(to.Url, Is.EqualTo(expectedUrl));
		}

		[Test]
		public void Map_ExtendedDouble_FailingEarlyInTheChain()
		{
			CultureInfo spanish = new CultureInfo("es-ES");
			string strId = "3A9779A4-9DCB-4FAC-ABBD-E61D8B27A8E4", name = "myself";
			Guid id = new Guid(strId);
			DateTime created = new DateTime(1977, 3, 11);
			string expectedUrl = "url";

			Entity from = new Entity { Id = id, CreationDate = created, Name = name };
			var writer = new UrlWriterDouble();
			var subject = new EntityMapper(writer);

			writer
				.Arrange(url => url.In(CultureInfo.InvariantCulture))
				.Arrange(url => url.Entity(id), expectedUrl)
				.Act(() => subject.Map(from, spanish));
		}

		[Test]
		public void Map_ExtendedDouble_FailingLateInTheChain()
		{
			CultureInfo spanish = new CultureInfo("es-ES");
			string strId = "3A9779A4-9DCB-4FAC-ABBD-E61D8B27A8E4", name = "myself";
			Guid id = new Guid(strId);
			DateTime created = new DateTime(1977, 3, 11);
			string expectedUrl = "url";

			Entity from = new Entity { Id = id, CreationDate = created, Name = name };
			var writer = new UrlWriterDouble();
			var subject = new EntityMapper(writer);

			writer
				.Arrange(url => url.In(spanish))
				.Arrange(url => url.Entity(Guid.Empty), expectedUrl)
				.Act(() => subject.Map(from, spanish));
		}
	}
}
