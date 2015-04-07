namespace DgonDotNet.Blog.Samples.ConfigurationValidation
{
	public interface IMyConfiguration
	{
		string PoorlyNamed { get; }
		string NeatlyNamed { get; }
	}
}