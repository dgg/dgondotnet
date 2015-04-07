using System.Globalization;

namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	public class EntityMapper
	{
		private readonly IUrlWriter _writer;

		public EntityMapper(IUrlWriter writer)
		{
			_writer = writer;
		}

		public EntityDto Map(Entity from, CultureInfo language)
		{
			return from != null ?
				new EntityDto(
					from.Id.ToString().ToUpper(),
					from.Name,
					from.CreationDate.ToString("yyyyMMdd"),
					_writer.Write(url => url.In(language).Entity(from.Id))) :
				new EntityDto(string.Empty, string.Empty, string.Empty, string.Empty);
		}
	}
}
