using System.Configuration;

namespace DgonDotNet.Blog.Samples.ConfigurationValidation
{
	public class MyNeatlyNamedElement : ConfigurationElement
	{
		internal static readonly string ElementName = "neatlyNamed";

		internal static readonly string NEATLY_NAMED = "neatEnough";
		private static readonly ConfigurationProperty _neatlyNamedProperty;
		public string NeatlyNamedProperty
		{
			get { return (string)base[_neatlyNamedProperty]; }
		}

		static MyNeatlyNamedElement()
		{
			_neatlyNamedProperty = new ConfigurationProperty(NEATLY_NAMED, typeof(string), null, null, new StringValidator(1), ConfigurationPropertyOptions.IsRequired);
			_properties = new ConfigurationPropertyCollection { _neatlyNamedProperty };
		}

		private static readonly ConfigurationPropertyCollection _properties;
		protected override ConfigurationPropertyCollection Properties
		{
			get { return _properties; }
		}
	}
}