using System.Configuration;

namespace DgonDotNet.Blog.Samples.ConfigurationValidation
{
	public class MyPoorlyNamedElement : ConfigurationElement
	{
		internal static readonly string ElementName = "poorlyNamed";

		internal static readonly string POORLY_NAMED = "poorlyNamed";
		private static readonly ConfigurationProperty _poorlyNamedProperty;
		public string PoorlyNamedProperty
		{
			get { return (string)base[_poorlyNamedProperty]; }
		}

		static MyPoorlyNamedElement()
		{
			_poorlyNamedProperty = new ConfigurationProperty(POORLY_NAMED, typeof(string), null, null, new StringValidator(1), ConfigurationPropertyOptions.IsRequired);
			_properties = new ConfigurationPropertyCollection { _poorlyNamedProperty };
		}

		private static readonly ConfigurationPropertyCollection _properties;
		protected override ConfigurationPropertyCollection Properties
		{
			get { return _properties; }
		}
	}
}