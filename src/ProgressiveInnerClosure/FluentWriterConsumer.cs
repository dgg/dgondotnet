using System;
using System.Globalization;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	[TestFixture]
	public class FluentWriterConsumer
	{
		[Test]
		public void WriteContent_UrlInDifferentLanguages()
		{
			var subject = new FluentUrlWriter();
			CultureInfo spanish = CultureInfo.GetCultureInfo("es-ES"), danish = CultureInfo.GetCultureInfo("da-DK");

			Assert.That(subject.Write(url => url.In(spanish).Content().X), Is.EqualTo("/es-es/content/x"));
			Assert.That(subject.Write(url => url.In(danish).Content().X), Is.EqualTo("/da-dk/content/x"));
		}

		[Test]
		public void WriteEntity_UrlInDifferentLanguages()
		{
			var subject = new FluentUrlWriter();
			CultureInfo spanish = CultureInfo.GetCultureInfo("es-ES"), danish = CultureInfo.GetCultureInfo("da-DK");
			string strId = "c959e4e3-79aa-4445-a362-08b9a1cee1d5";
			Guid id = new Guid(strId);

			Assert.That(subject.Write(url => url.In(spanish).Entity(id)), Is.EqualTo("/es-es/entity/" + strId));
			Assert.That(subject.Write(url => url.In(danish).Entity(id)), Is.EqualTo("/da-dk/entity/" + strId));
		}

		[Test]
		public void WriteFindEntity_UrlInDifferentLanguages()
		{
			var subject = new FluentUrlWriter();
			CultureInfo spanish = CultureInfo.GetCultureInfo("es-ES"), danish = CultureInfo.GetCultureInfo("da-DK");

			Assert.That(subject.Write(url => url.In(spanish).Entity().Find), Is.EqualTo("/es-es/entity/find"));
			Assert.That(subject.Write(url => url.In(danish).Entity().Op), Is.EqualTo("/da-dk/entity/op"));
		}

		[Test]
		public void WriteComplex_DifferentArguments()
		{
			var subject = new FluentUrlWriter();
			CultureInfo spanish = CultureInfo.GetCultureInfo("es-ES"), danish = CultureInfo.GetCultureInfo("da-DK");

			Assert.That(subject.Write(url => url.In(spanish).Complex().S1("s1").S2("s2_1").S2("s2_2").S3("s3")),
				Is.EqualTo("/es-es/complex/s1/s2_1/s2_2/s3"));

			Assert.That(subject.Write(url => url.In(spanish).Complex().S1("s1").S2("s2_1", "s2_2").S3("s3")),
				Is.EqualTo("/es-es/complex/s1/s2_1/s2_2/s3"));

			Assert.That(subject.Write(url => url.In(danish).Complex().S1("s1")),
				Is.EqualTo("/da-dk/complex/s1"));

			Assert.That(subject.Write(url => url.In(danish).Complex().S1("s1").S2("s2")),
				Is.EqualTo("/da-dk/complex/s1/s2"));

			// Exercise for the reader ;-)
			//Assert.That(subject.Write(url => url.In(spanish).Complex().S1("s1").S2(null).S3("s3")),
			//	Is.EqualTo("/es-es/complex/s1"));
		}
	}
}
