using System.Configuration;

namespace DgonDotNet.Blog.Samples.ConfigurationValidation
{
	internal class MyConfiguration : IMyConfiguration
	{
		private readonly MySection _section;

		public MyConfiguration()
		{
			_section = (MySection)ConfigurationManager.GetSection(MySection.SectionName);
		}

		public MyConfiguration(string configFile)
		{
			_section = (MySection)ConfigurationManager.OpenExeConfiguration(configFile).GetSection(MySection.SectionName);
		}

		public string PoorlyNamed { get { return _section.PoorlyNamed.PoorlyNamedProperty; } }

		public string NeatlyNamed { get { return _section.NeatlyNamed.NeatlyNamedProperty; } }	
	}
}
