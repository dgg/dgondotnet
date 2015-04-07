using System.Configuration;

namespace DgonDotNet.Blog.Samples.ConfigurationValidation
{
	public class MySection : ConfigurationSection
	{
		public static readonly string SectionName = "myConfiguration";

		private static readonly ConfigurationProperty _poorlyNamedElement;
		public MyPoorlyNamedElement PoorlyNamed
		{
			get { return (MyPoorlyNamedElement)base[_poorlyNamedElement]; }
		}

		private static readonly ConfigurationProperty _neatlyNamedElement;
		public MyNeatlyNamedElement NeatlyNamed
		{
			get { return (MyNeatlyNamedElement)base[_neatlyNamedElement]; }
		}


		static MySection()
		{
			_poorlyNamedElement = new ConfigurationProperty(MyPoorlyNamedElement.ElementName, typeof(MyPoorlyNamedElement), null, ConfigurationPropertyOptions.IsRequired);
			_neatlyNamedElement = new ConfigurationProperty(MyNeatlyNamedElement.ElementName, typeof(MyNeatlyNamedElement), null, ConfigurationPropertyOptions.IsRequired);
			_properties = new ConfigurationPropertyCollection { _poorlyNamedElement, _neatlyNamedElement };
		}

		private static readonly ConfigurationPropertyCollection _properties;
		protected override ConfigurationPropertyCollection Properties
		{
			get
			{
				return _properties;
			}
		}
	}
}