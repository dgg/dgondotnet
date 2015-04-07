using System;
using System.Globalization;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	[TestFixture]
	public class NonFluentWriterConsumer
	{
		[Test]
		public void WriteContent_UrlInDifferentLanguages()
		{
			var subject = new NonFluentUrlWriter();
			CultureInfo spanish = CultureInfo.GetCultureInfo("es-ES"), danish = CultureInfo.GetCultureInfo("da-DK");

			Assert.That(subject.WriteContent(spanish, "X"), Is.EqualTo("/es-es/content/x"));
			Assert.That(subject.WriteContent(danish, "X"), Is.EqualTo("/da-dk/content/x"));
		}

		[Test]
		public void WriteEntity_UrlInDifferentLanguages()
		{
			var subject = new NonFluentUrlWriter();
			CultureInfo spanish = CultureInfo.GetCultureInfo("es-ES"), danish = CultureInfo.GetCultureInfo("da-DK");
			string strId = "c959e4e3-79aa-4445-a362-08b9a1cee1d5";
			Guid id = new Guid(strId);

			Assert.That(subject.WriteEntity(spanish, id), Is.EqualTo("/es-es/entity/" + strId));
			Assert.That(subject.WriteEntity(danish, id), Is.EqualTo("/da-dk/entity/" + strId));
		}

		[Test]
		public void WriteFindEntity_UrlInDifferentLanguages()
		{
			var subject = new NonFluentUrlWriter();
			CultureInfo spanish = CultureInfo.GetCultureInfo("es-ES"), danish = CultureInfo.GetCultureInfo("da-DK");

			Assert.That(subject.WriteEntityOperation(spanish, "find"), Is.EqualTo("/es-es/entity/find"));
			Assert.That(subject.WriteEntityOperation(danish, "op"), Is.EqualTo("/da-dk/entity/op"));
		}

		[Test]
		public void WriteComplex_DifferentArguments()
		{
			var subject = new NonFluentUrlWriter();
			CultureInfo spanish = CultureInfo.GetCultureInfo("es-ES"), danish = CultureInfo.GetCultureInfo("da-DK");

			Assert.That(subject.WriteComplex(spanish, new ComplexArgument("s1", new[] { "s2_1", "s2_2" }, "s3")),
				Is.EqualTo("/es-es/complex/s1/s2_1/s2_2/s3"));

			Assert.That(subject.WriteComplex(danish, new ComplexArgument("s1")),
			Is.EqualTo("/da-dk/complex/s1"));

			Assert.That(subject.WriteComplex(danish, new ComplexArgument("s1", new[] { "s2" })),
				Is.EqualTo("/da-dk/complex/s1/s2"));

			Assert.That(subject.WriteComplex(spanish, new ComplexArgument("s1", new string[] { }, "s3")),
				Is.EqualTo("/es-es/complex/s1"));
		}
	}
}
