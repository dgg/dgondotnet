using System.Configuration;
using System.Resources;
using NUnit.Framework;

namespace DgonDotNet.Blog.Samples.ConfigurationValidation
{
	[TestFixture]
	public class Tester
	{
		[Test]
		public void CorrectConfig_CanGetValueFromProperty()
		{
			IMyConfiguration subject = new MyConfiguration("..\\..\\ConfigFiles\\CorrectConfig.dll");
			Assert.That(subject.NeatlyNamed, Is.EqualTo("neat"));
			Assert.That(subject.PoorlyNamed, Is.EqualTo("poor"));
		}

		[Test]
		public void MissingNeatlyNamedProperty_Exception()
		{
			Assert.That(() => new MyConfiguration("..\\..\\ConfigFiles\\MissingNeatProperty.dll"),
				Throws.InstanceOf<ConfigurationErrorsException>()
				.With.Message.StringStarting(missingMandatoryMessage(MyNeatlyNamedElement.NEATLY_NAMED)));
		}

		[Test]
		public void InvalidNeatlyNamedProperty_Exception()
		{
			var subject = new MyConfiguration("..\\..\\ConfigFiles\\InvalidNeatProperty.dll");

			string _ ;
			Assert.That(() => _ = subject.NeatlyNamed,
				Throws.InstanceOf<ConfigurationErrorsException>()
				.With.Message.StringStarting(invalidMessage(MyNeatlyNamedElement.NEATLY_NAMED)));
		}

		[Test]
		public void MissingPoorlyNamedProperty_NoException()
		{
			Assert.DoesNotThrow(() => new MyConfiguration("..\\..\\ConfigFiles\\MissingPoorProperty.dll"), 
				"No exception as the element has the same name as the property");
		}

		[Test]
		public void InvalidPoorlyNamedProperty_NoException()
		{
			var subject = new MyConfiguration("..\\..\\ConfigFiles\\InvalidPoorProperty.dll");

			string _;
			Assert.That(() => _ = subject.PoorlyNamed,
				Throws.InstanceOf<ConfigurationErrorsException>()
				.With.Message.StringStarting(invalidMessage(MyPoorlyNamedElement.POORLY_NAMED)));
		}

		private static readonly ResourceManager _rm = new ResourceManager("System.Configuration", typeof(ConfigurationManager).Assembly);
		private static string missingMandatoryMessage(string missingAttributeName)
		{
			return string.Format(_rm.GetString("Config_base_required_attribute_missing"), missingAttributeName);
		}

		private static string invalidMessage(string invalidAttributeName)
		{
			return string.Format(_rm.GetString("Top_level_validation_error"), invalidAttributeName, string.Empty);
		}
	}
}